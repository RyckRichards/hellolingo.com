USE [msdb]
GO

/****** Object:  Job [AutomarkSomeEmails]    Script Date: 9/28/2016 8:07:30 AM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 9/28/2016 8:07:30 AM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'AutomarkSomeEmails', 
		@enabled=1, 
		@notify_level_eventlog=2, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'HELLOLINGOVM1\MasterGardener', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [MarkToSendWhenThereHasBeenAnteriorReplies]    Script Date: 9/28/2016 8:07:31 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'MarkToSendWhenThereHasBeenAnteriorReplies', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=3, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'Update Mails Set RegulationStatus = 20, NotifyStatus = 5
WHERE exists (select id from mails M2 where Mails.Toid = M2.FromId and Mails.FromId = M2.Toid)
	and NotifyStatus = 1 
	AND FromId IN (SELECT Id FROM Users WHERE Status = 1 AND Banned = 0)
	AND ToId IN (SELECT Id FROM Users AS Users_1  WHERE Status = 1 AND Banned = 0)
', 
		@database_name=N'HelloLingo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [MarkSentContinuationOfPreviouslyAcceptedEmail]    Script Date: 9/28/2016 8:07:31 AM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'MarkSentContinuationOfPreviouslyAcceptedEmail', 
		@step_id=2, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'Update mails set RegulationStatus = 21, NotifyStatus = 21 
where RegulationStatus = 12 and NotifyStatus = 1
and exists (select id from Users where fromid in (Select id from users where status = 1 and banned = 0))
and exists (select id from Users where toid in (Select id from users where status = 1 and banned = 0))
and exists (
	select max([when])[when], fromid, toid from mails M2
	where RegulationStatus in (20,21)
	and notifyStatus <> 7
	and ToStatus = 10
	and replytomail is null
	and Mails.[When] > M2.[When]
	and Mails.FromId = M2.FromId
	and Mails.ToId = M2.ToId
	group by [when], fromid, toid
)', 
		@database_name=N'HelloLingo', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Every 10 minutes', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=4, 
		@freq_subday_interval=10, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20160920, 
		@active_end_date=99991231, 
		@active_start_time=900, 
		@active_end_time=235959, 
		@schedule_uid=N'a7d29820-382d-4498-befa-a132ee8f8bf5'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


