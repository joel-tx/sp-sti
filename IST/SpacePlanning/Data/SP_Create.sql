SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating schemas'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Address]'
GO
CREATE TABLE [dbo].[Address]
(
[address_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Address__address__42E1EEFE] DEFAULT (newid()),
[address_line_1] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[address_line_2] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[city] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[state] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[county] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[region] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[postal_code] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[country] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__Address__country__0F975522] DEFAULT ('USA')
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_address_id] on [dbo].[Address]'
GO
ALTER TABLE [dbo].[Address] ADD CONSTRAINT [PK_address_id] PRIMARY KEY CLUSTERED  ([address_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_address_id] on [dbo].[Address]'
GO
CREATE NONCLUSTERED INDEX [IDX_address_id] ON [dbo].[Address] ([address_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_address_full] on [dbo].[Address]'
GO
CREATE NONCLUSTERED INDEX [IDX_address_full] ON [dbo].[Address] ([address_line_1], [city], [state], [postal_code]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_address_city] on [dbo].[Address]'
GO
CREATE NONCLUSTERED INDEX [IDX_address_city] ON [dbo].[Address] ([city]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_address_city_state] on [dbo].[Address]'
GO
CREATE NONCLUSTERED INDEX [IDX_address_city_state] ON [dbo].[Address] ([city], [state]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_address_state] on [dbo].[Address]'
GO
CREATE NONCLUSTERED INDEX [IDX_address_state] ON [dbo].[Address] ([state]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Audit_Log]'
GO
CREATE TABLE [dbo].[Audit_Log]
(
[audit_log_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Audit_Log__audit__1C873BEC] DEFAULT (newid()),
[create_date] [datetime] NOT NULL,
[entry] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[level_id] [bigint] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_log_id] on [dbo].[Audit_Log]'
GO
ALTER TABLE [dbo].[Audit_Log] ADD CONSTRAINT [PK_log_id] PRIMARY KEY CLUSTERED  ([audit_log_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_created] on [dbo].[Audit_Log]'
GO
CREATE NONCLUSTERED INDEX [IDX_created] ON [dbo].[Audit_Log] ([create_date]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_level_created] on [dbo].[Audit_Log]'
GO
CREATE NONCLUSTERED INDEX [IDX_level_created] ON [dbo].[Audit_Log] ([create_date], [level_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Element]'
GO
CREATE TABLE [dbo].[Element]
(
[element_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Element__element__498EEC8D] DEFAULT (newid()),
[graphic_id] [uniqueidentifier] NOT NULL,
[element_type_id] [uniqueidentifier] NOT NULL,
[label] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_element_id] on [dbo].[Element]'
GO
ALTER TABLE [dbo].[Element] ADD CONSTRAINT [PK_element_id] PRIMARY KEY CLUSTERED  ([element_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_element_id] on [dbo].[Element]'
GO
CREATE NONCLUSTERED INDEX [IDX_element_id] ON [dbo].[Element] ([element_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Element_Type]'
GO
CREATE TABLE [dbo].[Element_Type]
(
[element_type_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Element_T__eleme__46B27FE2] DEFAULT (newid()),
[name] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_element_type_id] on [dbo].[Element_Type]'
GO
ALTER TABLE [dbo].[Element_Type] ADD CONSTRAINT [PK_element_type_id] PRIMARY KEY CLUSTERED  ([element_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_element_type_id] on [dbo].[Element_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_element_type_id] ON [dbo].[Element_Type] ([element_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_element_name] on [dbo].[Element_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_element_name] ON [dbo].[Element_Type] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Entity]'
GO
CREATE TABLE [dbo].[Entity]
(
[entity_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Entity__entity_i__55F4C372] DEFAULT (newid()),
[entity_type_id] [uniqueidentifier] NOT NULL,
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_entity_id] on [dbo].[Entity]'
GO
ALTER TABLE [dbo].[Entity] ADD CONSTRAINT [PK_entity_id] PRIMARY KEY CLUSTERED  ([entity_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_entity_id] on [dbo].[Entity]'
GO
CREATE NONCLUSTERED INDEX [IDX_entity_id] ON [dbo].[Entity] ([entity_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_entity_name] on [dbo].[Entity]'
GO
CREATE NONCLUSTERED INDEX [IDX_entity_name] ON [dbo].[Entity] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Entity_Type]'
GO
CREATE TABLE [dbo].[Entity_Type]
(
[entity_type_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Entity_Ty__entit__58D1301D] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_entity_type_id] on [dbo].[Entity_Type]'
GO
ALTER TABLE [dbo].[Entity_Type] ADD CONSTRAINT [PK_entity_type_id] PRIMARY KEY CLUSTERED  ([entity_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_entity_type_id] on [dbo].[Entity_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_entity_type_id] ON [dbo].[Entity_Type] ([entity_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_entity_type_name] on [dbo].[Entity_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_entity_type_name] ON [dbo].[Entity_Type] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Graphic]'
GO
CREATE TABLE [dbo].[Graphic]
(
[graphic_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Graphic__graphic__4C6B5938] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[height] [int] NULL,
[width] [int] NULL,
[graphic_type_id] [uniqueidentifier] NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_graphic_id] on [dbo].[Graphic]'
GO
ALTER TABLE [dbo].[Graphic] ADD CONSTRAINT [PK_graphic_id] PRIMARY KEY CLUSTERED  ([graphic_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_graphic_id] on [dbo].[Graphic]'
GO
CREATE NONCLUSTERED INDEX [IDX_graphic_id] ON [dbo].[Graphic] ([graphic_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_name] on [dbo].[Graphic]'
GO
CREATE NONCLUSTERED INDEX [IDX_name] ON [dbo].[Graphic] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Graphic_Type]'
GO
CREATE TABLE [dbo].[Graphic_Type]
(
[graphic_type_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Graphic_T__graph__625A9A57] DEFAULT (newid()),
[name] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_graphic_type_id] on [dbo].[Graphic_Type]'
GO
ALTER TABLE [dbo].[Graphic_Type] ADD CONSTRAINT [PK_graphic_type_id] PRIMARY KEY CLUSTERED  ([graphic_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_graphic_type_id] on [dbo].[Graphic_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_graphic_type_id] ON [dbo].[Graphic_Type] ([graphic_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_graphic_type_name] on [dbo].[Graphic_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_graphic_type_name] ON [dbo].[Graphic_Type] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Layer]'
GO
CREATE TABLE [dbo].[Layer]
(
[layer_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Layer__layer_id__681373AD] DEFAULT (newid()),
[scene_id] [uniqueidentifier] NOT NULL,
[layer_type_id] [uniqueidentifier] NOT NULL,
[zorder] [int] NULL,
[name] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_layer_id] on [dbo].[Layer]'
GO
ALTER TABLE [dbo].[Layer] ADD CONSTRAINT [PK_layer_id] PRIMARY KEY CLUSTERED  ([layer_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_layer_id] on [dbo].[Layer]'
GO
CREATE NONCLUSTERED INDEX [IDX_layer_id] ON [dbo].[Layer] ([layer_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_LayerID_SceneID] on [dbo].[Layer]'
GO
CREATE NONCLUSTERED INDEX [IDX_LayerID_SceneID] ON [dbo].[Layer] ([layer_id], [scene_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_layer_name] on [dbo].[Layer]'
GO
CREATE NONCLUSTERED INDEX [IDX_layer_name] ON [dbo].[Layer] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Layer_Type]'
GO
CREATE TABLE [dbo].[Layer_Type]
(
[layer_type_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Layer_Typ__layer__65370702] DEFAULT (newid()),
[name] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_layer_type_id] on [dbo].[Layer_Type]'
GO
ALTER TABLE [dbo].[Layer_Type] ADD CONSTRAINT [PK_layer_type_id] PRIMARY KEY CLUSTERED  ([layer_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_layer_type_id] on [dbo].[Layer_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_layer_type_id] ON [dbo].[Layer_Type] ([layer_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_layer_type_name] on [dbo].[Layer_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_layer_type_name] ON [dbo].[Layer_Type] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Lock]'
GO
CREATE TABLE [dbo].[Lock]
(
[lock_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Lock__lock_id__6DCC4D03] DEFAULT (newid()),
[scene_id] [uniqueidentifier] NOT NULL,
[layer_id] [uniqueidentifier] NOT NULL,
[element_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_lock_id] on [dbo].[Lock]'
GO
ALTER TABLE [dbo].[Lock] ADD CONSTRAINT [PK_lock_id] PRIMARY KEY CLUSTERED  ([lock_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Name]'
GO
CREATE TABLE [dbo].[Name]
(
[name_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Name__name_id__5D95E53A] DEFAULT (newid()),
[first] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[middle] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[last] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[prefix] [nvarchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[suffix] [nvarchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_name_id] on [dbo].[Name]'
GO
ALTER TABLE [dbo].[Name] ADD CONSTRAINT [PK_name_id] PRIMARY KEY CLUSTERED  ([name_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_first_last] on [dbo].[Name]'
GO
CREATE NONCLUSTERED INDEX [IDX_first_last] ON [dbo].[Name] ([first], [last]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_last] on [dbo].[Name]'
GO
CREATE NONCLUSTERED INDEX [IDX_last] ON [dbo].[Name] ([last]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_name_id] on [dbo].[Name]'
GO
CREATE NONCLUSTERED INDEX [IDX_name_id] ON [dbo].[Name] ([name_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Object]'
GO
CREATE TABLE [dbo].[Object]
(
[object_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Object__object_i__72910220] DEFAULT (newid()),
[name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_object_id] on [dbo].[Object]'
GO
ALTER TABLE [dbo].[Object] ADD CONSTRAINT [PK_object_id] PRIMARY KEY CLUSTERED  ([object_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_obj_name] on [dbo].[Object]'
GO
CREATE NONCLUSTERED INDEX [IDX_obj_name] ON [dbo].[Object] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_object_id] on [dbo].[Object]'
GO
CREATE NONCLUSTERED INDEX [IDX_object_id] ON [dbo].[Object] ([object_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Operation]'
GO
CREATE TABLE [dbo].[Operation]
(
[operation_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Operation__opera__7A3223E8] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_operation_id] on [dbo].[Operation]'
GO
ALTER TABLE [dbo].[Operation] ADD CONSTRAINT [PK_operation_id] PRIMARY KEY CLUSTERED  ([operation_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_op_name] on [dbo].[Operation]'
GO
CREATE NONCLUSTERED INDEX [IDX_op_name] ON [dbo].[Operation] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_operation_id] on [dbo].[Operation]'
GO
CREATE NONCLUSTERED INDEX [IDX_operation_id] ON [dbo].[Operation] ([operation_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Permission]'
GO
CREATE TABLE [dbo].[Permission]
(
[permission_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Permissio__permi__7755B73D] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_permission_id] on [dbo].[Permission]'
GO
ALTER TABLE [dbo].[Permission] ADD CONSTRAINT [PK_permission_id] PRIMARY KEY CLUSTERED  ([permission_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_perm_name] on [dbo].[Permission]'
GO
CREATE NONCLUSTERED INDEX [IDX_perm_name] ON [dbo].[Permission] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_permission_id] on [dbo].[Permission]'
GO
CREATE NONCLUSTERED INDEX [IDX_permission_id] ON [dbo].[Permission] ([permission_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[physical_element]'
GO
CREATE TABLE [dbo].[physical_element]
(
[physical_element_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__physical___physi__7EF6D905] DEFAULT (newid()),
[element_id] [uniqueidentifier] NOT NULL,
[layer_id] [uniqueidentifier] NOT NULL,
[startx] [int] NOT NULL,
[starty] [int] NOT NULL,
[endx] [int] NOT NULL,
[endy] [int] NOT NULL,
[zorder] [int] NULL,
[rotation] [int] NULL,
[color] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[label] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[barcode] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_physical_element_id] on [dbo].[physical_element]'
GO
ALTER TABLE [dbo].[physical_element] ADD CONSTRAINT [PK_physical_element_id] PRIMARY KEY CLUSTERED  ([physical_element_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_physical_element_id] on [dbo].[physical_element]'
GO
CREATE NONCLUSTERED INDEX [IDX_physical_element_id] ON [dbo].[physical_element] ([physical_element_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Plan]'
GO
CREATE TABLE [dbo].[Plan]
(
[plan_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Plan__plan_id__01D345B0] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[modify_date] [datetime] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_plan_id] on [dbo].[Plan]'
GO
ALTER TABLE [dbo].[Plan] ADD CONSTRAINT [PK_plan_id] PRIMARY KEY CLUSTERED  ([plan_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_plan_name] on [dbo].[Plan]'
GO
CREATE NONCLUSTERED INDEX [IDX_plan_name] ON [dbo].[Plan] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_plan_id] on [dbo].[Plan]'
GO
CREATE NONCLUSTERED INDEX [IDX_plan_id] ON [dbo].[Plan] ([plan_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Preference]'
GO
CREATE TABLE [dbo].[Preference]
(
[preference_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Preferenc__prefe__0697FACD] DEFAULT (newid()),
[data] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_preference] on [dbo].[Preference]'
GO
ALTER TABLE [dbo].[Preference] ADD CONSTRAINT [PK_preference] PRIMARY KEY CLUSTERED  ([preference_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_preference_id] on [dbo].[Preference]'
GO
CREATE NONCLUSTERED INDEX [IDX_preference_id] ON [dbo].[Preference] ([preference_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Role]'
GO
CREATE TABLE [dbo].[Role]
(
[role_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Role__role_id__0D44F85C] DEFAULT (newid()),
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_role_id] on [dbo].[Role]'
GO
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK_role_id] PRIMARY KEY CLUSTERED  ([role_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_role_name] on [dbo].[Role]'
GO
CREATE NONCLUSTERED INDEX [IDX_role_name] ON [dbo].[Role] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_role_id] on [dbo].[Role]'
GO
CREATE NONCLUSTERED INDEX [IDX_role_id] ON [dbo].[Role] ([role_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Scene]'
GO
CREATE TABLE [dbo].[Scene]
(
[scene_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Scene__scene_id__6AEFE058] DEFAULT (newid()),
[plan_id] [uniqueidentifier] NOT NULL,
[scene_type_id] [uniqueidentifier] NOT NULL,
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[modify_date] [datetime] NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_scene_id] on [dbo].[Scene]'
GO
ALTER TABLE [dbo].[Scene] ADD CONSTRAINT [PK_scene_id] PRIMARY KEY CLUSTERED  ([scene_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_scene_name] on [dbo].[Scene]'
GO
CREATE NONCLUSTERED INDEX [IDX_scene_name] ON [dbo].[Scene] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_scene_id] on [dbo].[Scene]'
GO
CREATE NONCLUSTERED INDEX [IDX_scene_id] ON [dbo].[Scene] ([scene_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Scene_Type]'
GO
CREATE TABLE [dbo].[Scene_Type]
(
[scene_type_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Scene_Typ__scene__10216507] DEFAULT (newid()),
[name] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_scene_type_id] on [dbo].[Scene_Type]'
GO
ALTER TABLE [dbo].[Scene_Type] ADD CONSTRAINT [PK_scene_type_id] PRIMARY KEY CLUSTERED  ([scene_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_scene_type_name] on [dbo].[Scene_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_scene_type_name] ON [dbo].[Scene_Type] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_scene_type_id] on [dbo].[Scene_Type]'
GO
CREATE NONCLUSTERED INDEX [IDX_scene_type_id] ON [dbo].[Scene_Type] ([scene_type_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Session]'
GO
CREATE TABLE [dbo].[Session]
(
[session_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Session__session__12FDD1B2] DEFAULT (newid()),
[value] [nvarchar] (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[create_date] [datetime] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_session_id] on [dbo].[Session]'
GO
ALTER TABLE [dbo].[Session] ADD CONSTRAINT [PK_session_id] PRIMARY KEY CLUSTERED  ([session_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_session_id] on [dbo].[Session]'
GO
CREATE NONCLUSTERED INDEX [IDX_session_id] ON [dbo].[Session] ([session_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Session_Log]'
GO
CREATE TABLE [dbo].[Session_Log]
(
[session_log_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Session_L__sessi__15DA3E5D] DEFAULT (newid()),
[session_id] [uniqueidentifier] NOT NULL,
[entry] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[level_id] [uniqueidentifier] NOT NULL,
[timestamp] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_session_log] on [dbo].[Session_Log]'
GO
ALTER TABLE [dbo].[Session_Log] ADD CONSTRAINT [PK_session_log] PRIMARY KEY CLUSTERED  ([session_log_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[User]'
GO
CREATE TABLE [dbo].[User]
(
[user_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__User__user_id__51300E55] DEFAULT (newid()),
[username] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[password] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[email] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[lockout_count] [int] NOT NULL,
[active_date] [datetime] NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_user_id] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_user_id] PRIMARY KEY CLUSTERED  ([user_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_user_id] on [dbo].[User]'
GO
CREATE NONCLUSTERED INDEX [IDX_user_id] ON [dbo].[User] ([user_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_username] on [dbo].[User]'
GO
CREATE NONCLUSTERED INDEX [IDX_username] ON [dbo].[User] ([username]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[User_Password_History]'
GO
CREATE TABLE [dbo].[User_Password_History]
(
[User_Password_History_id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__User_Pass__User___7FB5F314] DEFAULT (newid()),
[user_id] [uniqueidentifier] NOT NULL,
[from_date] [datetime] NOT NULL,
[password] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_user_password_history_id] on [dbo].[User_Password_History]'
GO
ALTER TABLE [dbo].[User_Password_History] ADD CONSTRAINT [PK_user_password_history_id] PRIMARY KEY CLUSTERED  ([User_Password_History_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_User_Password_History_id] on [dbo].[User_Password_History]'
GO
CREATE NONCLUSTERED INDEX [IDX_User_Password_History_id] ON [dbo].[User_Password_History] ([User_Password_History_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Log_Level]'
GO
CREATE TABLE [dbo].[Log_Level]
(
[log_level_id] [bigint] NOT NULL,
[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Log_Level] on [dbo].[Log_Level]'
GO
ALTER TABLE [dbo].[Log_Level] ADD CONSTRAINT [PK_Log_Level] PRIMARY KEY CLUSTERED  ([log_level_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_level_name] on [dbo].[Log_Level]'
GO
CREATE NONCLUSTERED INDEX [IDX_level_name] ON [dbo].[Log_Level] ([name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Element_User]'
GO
CREATE TABLE [dbo].[Element_User]
(
[element_id] [uniqueidentifier] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Element_User] on [dbo].[Element_User]'
GO
ALTER TABLE [dbo].[Element_User] ADD CONSTRAINT [PK_Element_User] PRIMARY KEY CLUSTERED  ([element_id], [user_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Entity_Address]'
GO
CREATE TABLE [dbo].[Entity_Address]
(
[address_id] [uniqueidentifier] NOT NULL,
[entity_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Entity_Address] on [dbo].[Entity_Address]'
GO
ALTER TABLE [dbo].[Entity_Address] ADD CONSTRAINT [PK_Entity_Address] PRIMARY KEY CLUSTERED  ([address_id], [entity_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Entity_Name]'
GO
CREATE TABLE [dbo].[Entity_Name]
(
[name_id] [uniqueidentifier] NOT NULL,
[entity_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Entity_Name] on [dbo].[Entity_Name]'
GO
ALTER TABLE [dbo].[Entity_Name] ADD CONSTRAINT [PK_Entity_Name] PRIMARY KEY CLUSTERED  ([name_id], [entity_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Entity_User]'
GO
CREATE TABLE [dbo].[Entity_User]
(
[entity_id] [uniqueidentifier] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Entity_User] on [dbo].[Entity_User]'
GO
ALTER TABLE [dbo].[Entity_User] ADD CONSTRAINT [PK_Entity_User] PRIMARY KEY CLUSTERED  ([entity_id], [user_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Lock_User]'
GO
CREATE TABLE [dbo].[Lock_User]
(
[user_id] [uniqueidentifier] NOT NULL,
[lock_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Lock_User] on [dbo].[Lock_User]'
GO
ALTER TABLE [dbo].[Lock_User] ADD CONSTRAINT [PK_Lock_User] PRIMARY KEY CLUSTERED  ([user_id], [lock_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Object_Permission]'
GO
CREATE TABLE [dbo].[Object_Permission]
(
[object_id] [uniqueidentifier] NOT NULL,
[permission_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Object_Permission] on [dbo].[Object_Permission]'
GO
ALTER TABLE [dbo].[Object_Permission] ADD CONSTRAINT [PK_Object_Permission] PRIMARY KEY CLUSTERED  ([object_id], [permission_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Operation_Permission]'
GO
CREATE TABLE [dbo].[Operation_Permission]
(
[operation_id] [uniqueidentifier] NOT NULL,
[permission_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Operation_Permission] on [dbo].[Operation_Permission]'
GO
ALTER TABLE [dbo].[Operation_Permission] ADD CONSTRAINT [PK_Operation_Permission] PRIMARY KEY CLUSTERED  ([operation_id], [permission_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Plan_User]'
GO
CREATE TABLE [dbo].[Plan_User]
(
[plan_id] [uniqueidentifier] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Plan_User] on [dbo].[Plan_User]'
GO
ALTER TABLE [dbo].[Plan_User] ADD CONSTRAINT [PK_Plan_User] PRIMARY KEY CLUSTERED  ([plan_id], [user_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Preference_User]'
GO
CREATE TABLE [dbo].[Preference_User]
(
[user_id] [uniqueidentifier] NOT NULL,
[preference_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Preference_User] on [dbo].[Preference_User]'
GO
ALTER TABLE [dbo].[Preference_User] ADD CONSTRAINT [PK_Preference_User] PRIMARY KEY CLUSTERED  ([user_id], [preference_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Role_Permission]'
GO
CREATE TABLE [dbo].[Role_Permission]
(
[role_id] [uniqueidentifier] NOT NULL,
[permission_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Role_Permission] on [dbo].[Role_Permission]'
GO
ALTER TABLE [dbo].[Role_Permission] ADD CONSTRAINT [PK_Role_Permission] PRIMARY KEY CLUSTERED  ([role_id], [permission_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Session_Role]'
GO
CREATE TABLE [dbo].[Session_Role]
(
[session_id] [uniqueidentifier] NOT NULL,
[role_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Session_Role] on [dbo].[Session_Role]'
GO
ALTER TABLE [dbo].[Session_Role] ADD CONSTRAINT [PK_Session_Role] PRIMARY KEY CLUSTERED  ([session_id], [role_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[User_Role]'
GO
CREATE TABLE [dbo].[User_Role]
(
[user_id] [uniqueidentifier] NOT NULL,
[role_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_User_Role] on [dbo].[User_Role]'
GO
ALTER TABLE [dbo].[User_Role] ADD CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED  ([user_id], [role_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[User_Settings]'
GO
CREATE TABLE [dbo].[User_Settings]
(
[user_setting_id] [uniqueidentifier] NOT NULL,
[user_id] [uniqueidentifier] NOT NULL,
[setting_name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[setting_value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_User_Settings] on [dbo].[User_Settings]'
GO
ALTER TABLE [dbo].[User_Settings] ADD CONSTRAINT [PK_User_Settings] PRIMARY KEY CLUSTERED  ([user_setting_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_UserID_SettingName] on [dbo].[User_Settings]'
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_UserID_SettingName] ON [dbo].[User_Settings] ([user_id], [setting_name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[System_Settings]'
GO
CREATE TABLE [dbo].[System_Settings]
(
[system_setting_id] [uniqueidentifier] NOT NULL,
[setting_name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[setting_value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_System_Settings] on [dbo].[System_Settings]'
GO
ALTER TABLE [dbo].[System_Settings] ADD CONSTRAINT [PK_System_Settings] PRIMARY KEY CLUSTERED  ([system_setting_id]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_SettingName] on [dbo].[System_Settings]'
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_SettingName] ON [dbo].[System_Settings] ([setting_name]) ON [PRIMARY]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Entity_Address]'
GO
ALTER TABLE [dbo].[Entity_Address] ADD CONSTRAINT [FK_Entity_Address_Address] FOREIGN KEY ([address_id]) REFERENCES [dbo].[Address] ([address_id])
GO
ALTER TABLE [dbo].[Entity_Address] ADD CONSTRAINT [FK_Entity_Address_Entity] FOREIGN KEY ([entity_id]) REFERENCES [dbo].[Entity] ([entity_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Audit_Log]'
GO
ALTER TABLE [dbo].[Audit_Log] ADD CONSTRAINT [FK_Audit_Log_Log_Level] FOREIGN KEY ([level_id]) REFERENCES [dbo].[Log_Level] ([log_level_id])
GO
ALTER TABLE [dbo].[Audit_Log] ADD CONSTRAINT [FK_Audit_Log_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Element_User]'
GO
ALTER TABLE [dbo].[Element_User] ADD CONSTRAINT [FK_Element_User_Element] FOREIGN KEY ([element_id]) REFERENCES [dbo].[Element] ([element_id])
GO
ALTER TABLE [dbo].[Element_User] ADD CONSTRAINT [FK_Element_User_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Lock]'
GO
ALTER TABLE [dbo].[Lock] ADD CONSTRAINT [FK_Lock_Element] FOREIGN KEY ([element_id]) REFERENCES [dbo].[Element] ([element_id])
GO
ALTER TABLE [dbo].[Lock] ADD CONSTRAINT [FK_Lock_Layer] FOREIGN KEY ([layer_id]) REFERENCES [dbo].[Layer] ([layer_id])
GO
ALTER TABLE [dbo].[Lock] ADD CONSTRAINT [FK_Lock_Scene] FOREIGN KEY ([scene_id]) REFERENCES [dbo].[Scene] ([scene_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[physical_element]'
GO
ALTER TABLE [dbo].[physical_element] ADD CONSTRAINT [FK_physical_element_Element] FOREIGN KEY ([element_id]) REFERENCES [dbo].[Element] ([element_id])
GO
ALTER TABLE [dbo].[physical_element] ADD CONSTRAINT [FK_physical_element_Layer] FOREIGN KEY ([layer_id]) REFERENCES [dbo].[Layer] ([layer_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Element]'
GO
ALTER TABLE [dbo].[Element] ADD CONSTRAINT [FK_Element_Graphic] FOREIGN KEY ([graphic_id]) REFERENCES [dbo].[Graphic] ([graphic_id])
GO
ALTER TABLE [dbo].[Element] ADD CONSTRAINT [FK_Element_Element_Type] FOREIGN KEY ([element_type_id]) REFERENCES [dbo].[Element_Type] ([element_type_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Entity_Name]'
GO
ALTER TABLE [dbo].[Entity_Name] ADD CONSTRAINT [FK_Entity_Name_Entity] FOREIGN KEY ([entity_id]) REFERENCES [dbo].[Entity] ([entity_id])
GO
ALTER TABLE [dbo].[Entity_Name] ADD CONSTRAINT [FK_Entity_Name_Name] FOREIGN KEY ([name_id]) REFERENCES [dbo].[Name] ([name_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Entity_User]'
GO
ALTER TABLE [dbo].[Entity_User] ADD CONSTRAINT [FK_Entity_User_Entity] FOREIGN KEY ([entity_id]) REFERENCES [dbo].[Entity] ([entity_id])
GO
ALTER TABLE [dbo].[Entity_User] ADD CONSTRAINT [FK_Entity_User_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Entity]'
GO
ALTER TABLE [dbo].[Entity] ADD CONSTRAINT [FK_Entity_Entity_Type] FOREIGN KEY ([entity_type_id]) REFERENCES [dbo].[Entity_Type] ([entity_type_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Graphic]'
GO
ALTER TABLE [dbo].[Graphic] ADD CONSTRAINT [FK_Graphic_Graphic_Type] FOREIGN KEY ([graphic_type_id]) REFERENCES [dbo].[Graphic_Type] ([graphic_type_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Layer]'
GO
ALTER TABLE [dbo].[Layer] ADD CONSTRAINT [FK_Layer_Scene] FOREIGN KEY ([scene_id]) REFERENCES [dbo].[Scene] ([scene_id])
GO
ALTER TABLE [dbo].[Layer] ADD CONSTRAINT [FK_Layer_Layer_Type] FOREIGN KEY ([layer_type_id]) REFERENCES [dbo].[Layer_Type] ([layer_type_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Lock_User]'
GO
ALTER TABLE [dbo].[Lock_User] ADD CONSTRAINT [FK_Lock_User_Lock] FOREIGN KEY ([lock_id]) REFERENCES [dbo].[Lock] ([lock_id])
GO
ALTER TABLE [dbo].[Lock_User] ADD CONSTRAINT [FK_Lock_User_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Object_Permission]'
GO
ALTER TABLE [dbo].[Object_Permission] ADD CONSTRAINT [FK_Object_Permission_Object] FOREIGN KEY ([object_id]) REFERENCES [dbo].[Object] ([object_id])
GO
ALTER TABLE [dbo].[Object_Permission] ADD CONSTRAINT [FK_Object_Permission_Permission] FOREIGN KEY ([permission_id]) REFERENCES [dbo].[Permission] ([permission_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Operation_Permission]'
GO
ALTER TABLE [dbo].[Operation_Permission] ADD CONSTRAINT [FK_Operation_Permission_Operation] FOREIGN KEY ([operation_id]) REFERENCES [dbo].[Operation] ([operation_id])
GO
ALTER TABLE [dbo].[Operation_Permission] ADD CONSTRAINT [FK_Operation_Permission_Permission] FOREIGN KEY ([permission_id]) REFERENCES [dbo].[Permission] ([permission_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Role_Permission]'
GO
ALTER TABLE [dbo].[Role_Permission] ADD CONSTRAINT [FK_Role_Permission_Permission] FOREIGN KEY ([permission_id]) REFERENCES [dbo].[Permission] ([permission_id])
GO
ALTER TABLE [dbo].[Role_Permission] ADD CONSTRAINT [FK_Role_Permission_Role] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Role] ([role_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Plan_User]'
GO
ALTER TABLE [dbo].[Plan_User] ADD CONSTRAINT [FK_Plan_User_Plan] FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Plan] ([plan_id])
GO
ALTER TABLE [dbo].[Plan_User] ADD CONSTRAINT [FK_Plan_User_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Scene]'
GO
ALTER TABLE [dbo].[Scene] ADD CONSTRAINT [FK_Scene_Plan] FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Plan] ([plan_id])
GO
ALTER TABLE [dbo].[Scene] ADD CONSTRAINT [FK_Scene_Scene_Type] FOREIGN KEY ([scene_type_id]) REFERENCES [dbo].[Scene_Type] ([scene_type_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Preference_User]'
GO
ALTER TABLE [dbo].[Preference_User] ADD CONSTRAINT [FK_Preference_User_Preference] FOREIGN KEY ([preference_id]) REFERENCES [dbo].[Preference] ([preference_id])
GO
ALTER TABLE [dbo].[Preference_User] ADD CONSTRAINT [FK_Preference_User_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Session_Role]'
GO
ALTER TABLE [dbo].[Session_Role] ADD CONSTRAINT [FK_Session_Role_Role] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Session_Role] ADD CONSTRAINT [FK_Session_Role_Session] FOREIGN KEY ([session_id]) REFERENCES [dbo].[Session] ([session_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[User_Role]'
GO
ALTER TABLE [dbo].[User_Role] ADD CONSTRAINT [FK_User_Role_Role] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[User_Role] ADD CONSTRAINT [FK_User_Role_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Session_Log]'
GO
ALTER TABLE [dbo].[Session_Log] ADD CONSTRAINT [FK_Session_Log_Session] FOREIGN KEY ([session_id]) REFERENCES [dbo].[Session] ([session_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[User_Password_History]'
GO
ALTER TABLE [dbo].[User_Password_History] ADD CONSTRAINT [FK_User_Password_History_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[User_Settings]'
GO
ALTER TABLE [dbo].[User_Settings] ADD CONSTRAINT [FK_User_Settings_User] FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating extended properties'
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents an optional physical address for an Entity.  An Entity can have zero to many addresses. For example, a business may have multiple branch locations or an employee can have a work address and a home address.  Address relates to Entity through the Entity_Address mapping table.', 'SCHEMA', N'dbo', 'TABLE', N'Address', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents an optional Audit logging entry.  User activity for audit trail purposes will be logged to this table.  Audit_Log directly relates to a record in the User table and must contain a reference to a Log_Level record.', 'SCHEMA', N'dbo', 'TABLE', N'Audit_Log', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional Entity information.  An Entity can have zero to many individual user records. For example, a business may have multiple accountants which each have their own user record for accessing the application.  Additionally, a consultant may also work for several companies or project teams.', 'SCHEMA', N'dbo', 'TABLE', N'Entity', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Address records and Entity records.  In order to obtain address information for a specific entity, join this table with Address in the SQL query and vise-versa for entity information for a specific address.', 'SCHEMA', N'dbo', 'TABLE', N'Entity_Address', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Name records and Entity records.  In order to obtain name information for a specific entity, join this table with Name in the SQL query and vise-versa for entity information for a specific name.', 'SCHEMA', N'dbo', 'TABLE', N'Entity_Name', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents a required entity type for an Entity record.  This entity information must have one entity type reference, i.e. "company", "accountant", "branch", "security team", etc.  Entity_Type directly relates to the Entity table.', 'SCHEMA', N'dbo', 'TABLE', N'Entity_Type', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between User records and Entity records.  In order to obtain user information for a specific entity, join this table with User in the SQL query and vise-versa for entity information for a specific user.', 'SCHEMA', N'dbo', 'TABLE', N'Entity_User', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents a required logging level for a Audit or Session log entry.  A record in either one of the log tables must have one log record type reference, i.e. "warning", "error", "critical", "info", etc.  Log_Level directly relates to both Session_Log and Audit_Log table records.', 'SCHEMA', N'dbo', 'TABLE', N'Log_Level', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents an optional name for an Entity.  An Entity can have zero to many names and a name can relate to zero to many entities. For example, a business may have a primary name and also a D/B/A name.  In the same manner, each branch of a business can have the same name as the business (like McDonalds).  Name relates to Entity through the Entity_Name mapping table.', 'SCHEMA', N'dbo', 'TABLE', N'Name', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional Object information.  Objects are the things upon which actions can be performed and can have zero to many individual permission records. For example, a financial report may have multiple permissions which can be assigned to a team of accountants and also developers for maintenance.  Additionally, many objects can share the same permission level such as the several pages which make up an admin dashboard.  In this example, each of these pages would have an administrator-only permission level.', 'SCHEMA', N'dbo', 'TABLE', N'Object', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Permission records and Object records.  In order to obtain permission information for a specific object, join this table with Object in the SQL query and vise-versa for object information for a specific permission.', 'SCHEMA', N'dbo', 'TABLE', N'Object_Permission', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional Operation information.  Operations are the actions that act upon Objects and can have zero to many individual permission records. For example, a financial report may have multiple operations which can be assigned to it based upon the permission level assigned to that operation, i.e. an admin-only permission level could include "update", "read", "copy", "modify", "delete" operations whereas a guest-only permission could have only "read" operations.  Operation records relate to Permission records through the Operation_Permission mapping table.', 'SCHEMA', N'dbo', 'TABLE', N'Operation', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Permission records and Operation records.  In order to obtain permission information for a specific operation, join this table with Permission in the SQL query and vise-versa for operation information for a specific permission.', 'SCHEMA', N'dbo', 'TABLE', N'Operation_Permission', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional Permission information.  Permissions allow or prevent an action upon an Object and can define further behavior.  For example, an admin-only permission level could include the "update", "read", "copy", "modify", "delete" operations whereas a guest-only permission could have just "read" operations. Permission records relate to Operation records through the Operation_Permission mapping table.', 'SCHEMA', N'dbo', 'TABLE', N'Permission', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table represents user preference storage.', 'SCHEMA', N'dbo', 'TABLE', N'Preference', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional Role information.  Roles encapsulate permission information and can be assigned to zero-to-many users and also zero-to-many sessions.  A user can then, therefore, be assigned to a single or many roles which can subsequently define the actions for a wide range of objects.  If a user needs a temporary role (and permissions), their user session can be "promoted" to a higher role.  Depending on session management as handled by the application, this temporary session-role promotion could last until revoked or until the session expires.  Role records relate to User records through the User_Role mapping table and relate to Session records through the Session_Role mapping table.', 'SCHEMA', N'dbo', 'TABLE', N'Role', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Permission records and Role records.  In order to obtain permission information for a specific role or list of roles, join this table with Permission in the SQL query and vise-versa for role information for a specific permission.', 'SCHEMA', N'dbo', 'TABLE', N'Role_Permission', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents optional user session information.  A Session can be used to maintain state for stateless applications or as a global role->permission cache for stateful applications.  Sessions can also be temporarily "promoted" to different roles on a temporary basis thereby allowing a User to perform a needed business function without needing to permanently modify their Role information.  Session directly relates to a record in the User table and can also related to zero-to-many records in the Role table.', 'SCHEMA', N'dbo', 'TABLE', N'Session', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents a required Session logging entry.  If a user session exists, activity for that session will be logged to this table.  Session_Log directly relates to a record in the Session table and must contain a reference to a Log_Level record.', 'SCHEMA', N'dbo', 'TABLE', N'Session_Log', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between Session records and Role records.  In order to obtain session information for a specific role or group of roles, join this table with Session in the SQL query and vise-versa for role information for a specific session.', 'SCHEMA', N'dbo', 'TABLE', N'Session_Role', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This model element represents required User information.  Users are the primary objects defined to manage authentication, role, session and related entity information.  User records directly relate to records in the Audit_Log and Session tables and relate to Role and Entity information through their respective mapping tables.  With this design, a user can have a rich combination of roles and permissions through which they can perform a variety of work actions on many diverse Objects.', 'SCHEMA', N'dbo', 'TABLE', N'User', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', 'This table stores the relational mapping (or association) between User records and Role records.  In order to obtain user information for a specific role or list of roles, join this table with User in the SQL query and vise-versa for role information for a specific user.', 'SCHEMA', N'dbo', 'TABLE', N'User_Role', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
