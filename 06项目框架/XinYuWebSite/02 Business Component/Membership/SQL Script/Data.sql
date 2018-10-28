

DECLARE @SupperUserID    int
DECLARE @SupperUserName  nvarchar(50)
DECLARE @SupperUserAlias nvarchar(50)

SET @SupperUserName  = 'Supper'
SET @SupperUserAlias =  '��������Ա'

Truncate Table [Membership].[User]
Truncate Table [Membership].[Role]
Truncate Table [Membership].[Module]



-- -----------------------------------------------------------------------------------------------
-- ���ӻ����û�
-- -----------------------------------------------------------------------------------------------
INSERT INTO [Membership].[User]
    ([UserName], [Password], [Alias], [Email], [Description],
    [PasswordQuestion], [PasswordAnswer], [SessionIdentify], 
    [IsSystem], [IsAdmin], [IsApproved], [IsLockedOut], [RoleIDs], [PopedomIDs],
    [LastLoginDate], [LastActivityDate], [LastPwdChangedDate], [LastLockoutDate], 
    [FailedPwdAttemptCount], [FailedPwdAttemptDate], [FailedPwdAnswerAttemptCount], [FailedPwdAnswerAttemptDate],
    [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
VALUES
    (@SupperUserName, '1B2M2Y8AsgTpgAmY7PhCfg==', @SupperUserAlias, '', '',
    '', '', '',
    1, 1, 1, 0, '', '',
    GETDATE(), GETDATE(), GETDATE(), GETDATE(),
    0, GETDATE(), 0, GETDATE(),
    0, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())

SELECT @SupperUserID = @@IDENTITY


-- -----------------------------------------------------------------------------------------------
-- ���Ӳ˵�
-- -----------------------------------------------------------------------------------------------
DECLARE @MenuTopID                int
DECLARE @MenuAccountManagementID  int
DECLARE @MenuDataManagementID     int
DECLARE @MenuSystemManagementID   int

DECLARE @MenuDzwlSBManagementID   int
DECLARE @MenuDzwlZDManagementID   int
DECLARE @MenuDzwlCNManagementID   int

SET @MenuTopID = 0

-- һ���˵�
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, '�˻�����',     '', '', 1, 1, 1, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuAccountManagementID = @@IDENTITY
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, '�������ݹ���', '', '', 1, 1, 0, 200, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuDataManagementID = @@IDENTITY
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, 'ϵͳ����',     '', '', 1, 1, 0, 300, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuSystemManagementID = @@IDENTITY

-- �˻�����˵�
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '�鿴����', '', 'Calendar.htm',               1, 0, 1, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '�޸�����', '', 'SysManager/UserUpdPwd.aspx', 1, 0, 1, 200, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '�˻�����', '', 'SysManager/UserUpd.aspx',    1, 0, 1, 300, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())


-- �������ݹ���˵�

-- ϵͳ����˵�
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�޸Ĳ˵�',     '', 'SysManager/ModuleAdd.aspx?id=',      0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�˵�����',     '', 'SysManager/ModuleManager.aspx',      1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '���ӽ�ɫ',     '', 'SysManager/RoleAdd.aspx',            1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�޸Ľ�ɫ',     '', 'SysManager/RoleAdd.aspx?id=',        0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '��ɫ����',     '', 'SysManager/RoleManager.aspx',        1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '��ɫȨ�޷���', '', 'SysManager/RolePopedomManager.aspx', 1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�����û�',     '', 'SysManager/UserAdd.aspx',            1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�޸��û�',     '', 'SysManager/UserAdd.aspx?id=',        0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�û�����',     '', 'SysManager/UserManager.aspx',        1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '�û�Ȩ�޷���', '', 'SysManager/UserPopedomManager.aspx', 1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, 'Ԥ���û�Ȩ��', '', 'SysManager/UserPopedomView.aspx',    1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())