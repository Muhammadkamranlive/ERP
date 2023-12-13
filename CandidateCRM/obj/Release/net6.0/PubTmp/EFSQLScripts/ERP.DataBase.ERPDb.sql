IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [MiddleName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NOT NULL,
        [personal] bit NULL,
        [EmergencyContact] bit NULL,
        [Education] bit NULL,
        [ProfessionalLicense] bit NULL,
        [JobExp] bit NULL,
        [Dependents] bit NULL,
        [FileManager] bit NULL,
        [Asset] bit NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Attachments] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [DocType] nvarchar(max) NOT NULL,
        [DocName] nvarchar(max) NOT NULL,
        [DocumentUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.DocumentManagement.Domain.Attachments_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [CandidateInfos] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [OrganizationName] nvarchar(max) NOT NULL,
        [BusinessType] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Website] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [ContactName] nvarchar(max) NOT NULL,
        [Position] nvarchar(max) NOT NULL,
        [BusinessEmail] nvarchar(max) NOT NULL,
        [PersonalEmail] nvarchar(max) NOT NULL,
        [MobilePhone] nvarchar(max) NOT NULL,
        [OfficePhone] nvarchar(max) NOT NULL,
        [Notes] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.CandidateInfo_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Dependents] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Relationship] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [HasSpecialNeeds] bit NOT NULL,
        [Notes] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.Dependent_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Educations] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [SchoolName] nvarchar(max) NOT NULL,
        [Degree] nvarchar(max) NOT NULL,
        [FieldOfStudy] nvarchar(max) NOT NULL,
        [YearOfCompletion] int NOT NULL,
        [GPA] float NOT NULL,
        [Interests] nvarchar(max) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.Education_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [GENERALTASKs] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [DueDate] datetime2 NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.TaskManagement.Domain.GENERALTASK_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [HRNotes] (
        [Id] uniqueidentifier NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        [HRId] nvarchar(max) NOT NULL,
        [Note] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.HRAdminStaff.Domain.HRNotes_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [JobExperiences] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [PreviousCompany] nvarchar(max) NOT NULL,
        [PreviousCompanyAddress] nvarchar(max) NOT NULL,
        [JobTitle] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [FromDate] datetime2 NOT NULL,
        [ToDate] datetime2 NOT NULL,
        [JobDescription] nvarchar(max) NULL,
        [ReasonForLeaving] nvarchar(max) NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.JobExperience_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [NOTIFICATIONs] (
        [Id] uniqueidentifier NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        [Timestamp] datetime2 NOT NULL,
        [IsRead] bit NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        [WorkflowStep] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.Notifications.Domain.NOTIFICATIONS_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [PasswordResetDomains] (
        [Id] uniqueidentifier NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [OTP] nvarchar(max) NOT NULL,
        [ExpireTime] datetime2 NOT NULL,
        CONSTRAINT [PK_ERP.Authentication.Domain.PasswordResetDomain_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Personals] (
        [Id] uniqueidentifier NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        [SSN] nvarchar(max) NOT NULL,
        [DOB] datetime2 NOT NULL,
        [Age] int NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [Race] nvarchar(max) NOT NULL,
        [Ethnicity] nvarchar(max) NOT NULL,
        [Nationality] nvarchar(max) NOT NULL,
        [Photo] nvarchar(max) NOT NULL,
        [HomePhone] nvarchar(max) NOT NULL,
        [MobilePhone] nvarchar(max) NOT NULL,
        [Carrier] nvarchar(max) NOT NULL,
        [PersonalEmail] nvarchar(max) NOT NULL,
        [BusinessEmail] nvarchar(max) NOT NULL,
        [BusinessPhone] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [ZipCode] nvarchar(max) NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [BestTimeToContact] nvarchar(max) NOT NULL,
        [HowDidYouHearAboutUs] nvarchar(max) NOT NULL,
        [Profession] nvarchar(max) NOT NULL,
        [Specialty] nvarchar(max) NOT NULL,
        [TypeOfEmployment] nvarchar(max) NOT NULL,
        [YearsOfExperience] int NOT NULL,
        [ComputerChartingSystemExperience] nvarchar(max) NOT NULL,
        [DesiredTravelArea] nvarchar(max) NOT NULL,
        [LocationPreference] nvarchar(max) NOT NULL,
        [AcceptTermsAndConditions] bit NOT NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.Personal_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [ProfessionalLicenses] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(max) NOT NULL,
        [LicenseName] nvarchar(max) NOT NULL,
        [LicenseType] nvarchar(max) NOT NULL,
        [StateOfLicense] nvarchar(max) NOT NULL,
        [LicenseNumber] nvarchar(max) NOT NULL,
        [Notes] nvarchar(max) NOT NULL,
        [IssueDate] datetime2 NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        CONSTRAINT [PK_ERP.ProfileManagement.Domain.ProfessionalLicense_Id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Assets] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(450) NOT NULL,
        [ItemName] nvarchar(max) NOT NULL,
        [Category] nvarchar(max) NOT NULL,
        [Manufacturer] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [ItemCode] nvarchar(max) NOT NULL,
        [ModelNo] nvarchar(max) NOT NULL,
        [SerialOrLicenseNo] nvarchar(max) NOT NULL,
        [ExpiryDate] datetime2 NULL,
        [WarrantyTill] datetime2 NULL,
        [Note] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.DocumentManagement.Domain.Asset_Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Assets_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [Cases] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [CustomerId] nvarchar(450) NOT NULL,
        [AgentId] nvarchar(max) NOT NULL,
        [AssignedAgentId] nvarchar(450) NULL,
        CONSTRAINT [PK_ERP.CaseManagement.Domain.Case_Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Cases_AspNetUsers_AssignedAgentId] FOREIGN KEY ([AssignedAgentId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Cases_AspNetUsers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [CONTACTDETAILs] (
        [Id] uniqueidentifier NOT NULL,
        [userId] nvarchar(450) NOT NULL,
        [HomePhone] nvarchar(max) NOT NULL,
        [MobilePhone] nvarchar(max) NOT NULL,
        [Carrier] nvarchar(max) NOT NULL,
        [PersonalEmail] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ContactManagement.CONTACTDETAILS_Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CONTACTDETAILs_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [EmergencyContacts] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Relationship] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [IsPrimary] bit NOT NULL,
        [Notes] nvarchar(max) NOT NULL,
        [userId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_ContactManagement.EmergencyContacts_Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EmergencyContacts_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE TABLE [CaseComments] (
        [Id] uniqueidentifier NOT NULL,
        [Text] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CaseId] uniqueidentifier NOT NULL,
        [UserId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ERP.CaseManagement.Domain.CaseComment_Id] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CaseComments_Cases_CaseId] FOREIGN KEY ([CaseId]) REFERENCES [Cases] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_Assets_userId] ON [Assets] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_CaseComments_CaseId] ON [CaseComments] ([CaseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_Cases_AssignedAgentId] ON [Cases] ([AssignedAgentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_Cases_CustomerId] ON [Cases] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_CONTACTDETAILs_userId] ON [CONTACTDETAILs] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    CREATE INDEX [IX_EmergencyContacts_userId] ON [EmergencyContacts] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128041903_InitialModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128041903_InitialModel', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128042213_InitialModel1')
BEGIN
    ALTER TABLE [GENERALTASKs] ADD [Progress] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128042213_InitialModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128042213_InitialModel1', N'6.0.20');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128180232_InitialModel4')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [image] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128180232_InitialModel4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128180232_InitialModel4', N'6.0.20');
END;
GO

COMMIT;
GO

