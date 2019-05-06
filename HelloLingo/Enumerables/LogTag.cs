﻿// ReSharper disable InconsistentNaming
namespace Considerate.Hellolingo {

	public enum LogTag
	{
		MailToDeletedUser, InexistentMailIdRequested, ReplyToInvalidMailId, UnauthorizedMailContentRequested,
		InvalidPrivateRoomWithOneself, MailToInexistentUser, RejectedBrowser, MailMarkedAsRead,
		PrivateChatWithUserNoLongerInChat, UnrecognizedBrowser, Log4NetLoggingStarted, Application_Ending, Application_Ended,
		SavedStateAt,  XirsysRequestError, AttemptToLogInWithUnknownUserName, AttemptToLogInWithInvalidUser, LogInFailed, LogInSuccess,
		SignUpEmailAlreadyInUse, SignUpPasswordIsTooWeak, SignUpSuccess, VisitFromDeletedProfile,
		PostProfile_TagsOnly, PostProfile_NoChange, PostProfile_WrongPassword, LogOff, UserNotFoundForGetProfileRequest,
		InvalidModelStateReceiveByPostMail, UnhandledApplicationException, EmailNotConfirmedForPasswordRecovery, 
		InvalidLogInModelState, InvalidSignUpModelState, AspNetUserCreationError, SignUpUserCreationReturnedNull,
		SignUpEntityValidationErrors, SignUpEntitySaveChangesError, PostProfile_InvalidModelState, FailedUpdateUserPassword,
		UserProfileEntityValidationErrors, UserProfileEntitySaveChangesError, EmailAlreadyInUse, SaveUsersChanges_EntityError,
		SaveUsersChanges_EntityValidationErrors, PostProfile_InvalidUserId, BaseApi_GetDeviceTagError, Executing,
		FourOFour_Page_Not_Found, UserLastVisitUpdateError, UnhandledMvcException, SaveSignalRStateFailed, LoggingError,
		UnhandledWebApiException, HeartBeat_OnError, HealthReport_OnError, TextChatHub_AlreadyCleaned,
		HeartbeatCheckError, UnknownReportLevel, ClientJoinedRoom, SavingAcceptedCallToDb, ClientTryingToLeaveAllRooms,
		SavingInitiatedCallToDb, VoiceCallRoomAlreadyExistsOnInitiatingCall, AcceptedVoiceCallRoomIdNotFoundDictionary,
		ClientTryingToLeaveRoom, ClientHaveLeftRoom, ReceivedCallFinished, SavingCallOutcome, MalformedXirsysResponse,
		XirsysResponse, ClientAlreadyConnected, ClientConnected, ClientClosedConnection, ClientTimedOut, ClientReconnected,
		PostToFailedDueToMissingDeviceTag, NecessaryCookiesMissingOrCorrupted, ForcingUnknownClientToReconnect, OutArgs,
		ManagedQueue_OnUnexpectedAckOrderId, InArgs, ManagedQueue_OnUnexpectedResendOrderIds, InvalidConcurrentVoiceCalls, 
		TextChatHub_CleaningConnection, CleaningZombieConnection, HubHeartbeatCheckCompleted, ChatHubHealthReport,
		UnknownClientReportLevel, IgnoredHeadRequest, EmailValidationMissingParams, OnUnexpectedAckOrderIdListenerRequired,
		EmailValidationFailed, CompletingSignUpFailed, UnknownUserIdClaimed, EmailForPasswordRecoveryNotFound,
		InvalidModelStateForPasswordRecovery, EmailNotFoundForPasswordReset, PasswordResetFailed, PasswordResetDone,
		ContactUsMessageDumped, ContactUsMessageDumpFailed, DeleteUser_InvalidModelState, PasswordRecoveryEmailSent,
		InvalidPasswordOnCancelAccount, EmailNotFoundForPasswordResetRequest, EmailSent_PasswordReset, InvalidModelStateInForgotPassword,
		OnMaxDelayReachedListenerRequired, LogOffUnauthenticatedUser, OnMessagesListenerRequired, ProcessingEmailNotificationQueue,
		InvalidModelStateInResetPassword, EmailSent_ContactUsForm, ChatPostRejectedOnInvalidUser, UpdateTileFilters_SaveChanges,
		MailNotificationsJobStarted, MessageNotificationsSent, MailNotificationsJobFailed, PostMail_SenderCannotMailHimself,
        SaveUserEmailConfirmedStatusError, VerifyEmail_InvalidUserId, UnsupportedUsageOfSendMail, SendCustomMail,
		EmailSent_EmailConfirmation, EmailSent_ChatKeywordAlert, ClientLoggingFailed, ClientLoggingReceivedNullData,
		MailingEmailShouldNotBeNull, SubjectShouldNotBeNull, HtmlBodyShouldNotBeNull, TextBodyShouldNotBeNull, 
		ManagedQueue_OnQueueOverflow, LoggedInUserNotFound,  MissingDeviceTag, UserAlreadyInContacts,
        InvalidSendEmailVerificationNonPendingUser, ChatRequestAccepted, PrivateChatIgnored,
		EmailValidationBypassedForTestEmail, UnexpectedEmailTypeOnQuotaValidator, CultureAwareActivator_UserNotFound,
		EmailValidationIsAlreadyDone, EmailValidationWrongEmail, UnobservedTaskException,
		PrivateRoomIntrusionAttempt, PasswordDiffersAtPasswordReset, PrivateChatRequested, ResendingMessages,
		RequestPrivateChatHasExistingRecord, IgnorePrivateChatMissingTrackerRecord, CreatingTrackerRecordsFromPostToRoom,
		UnexpectedTrackerStatus, Application_Started, OnQueueOverflowListenerRequired,
		ChatRequestAddedFromJoinRoom, OnUnexpectedResendOrderIdListenerRequired, XirsysTokenResponse,
		RequestedHostName, KickSlackerOutOfRoom, SetChatUserIdle, UnknownRoomType,
		UnexpectedSituation, UseFactoryInsteadOfClassInstantiation,
		UnexpectedNullIPV4, FailedToConvertIPV4ToUInt
	}
}