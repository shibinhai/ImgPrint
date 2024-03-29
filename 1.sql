USE [PrintImg]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 03/28/2019 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[userpwd] [nvarchar](50) NOT NULL,
	[qx] [nvarchar](50) NOT NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (1, N'admin', N'1111', N'1', NULL)
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (2, N'dahai', N'e10adc3949ba59abbe56e057f20f883e', N'0', CAST(0x0000AA1D00F9D378 AS DateTime))
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (3, N'dsf', N'e10adc3949ba59abbe56e057f20f883e', N'0', CAST(0x0000AA1D00FBC925 AS DateTime))
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (4, N'ytr', N'e10adc3949ba59abbe56e057f20f883e', N'0', CAST(0x0000AA1D00FBD1BE AS DateTime))
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (5, N'iytyt', N'e10adc3949ba59abbe56e057f20f883e', N'0', CAST(0x0000AA1D00FBDA08 AS DateTime))
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (6, N'trtdg', N'e10adc3949ba59abbe56e057f20f883e', N'0', CAST(0x0000AA1D00FBE2DF AS DateTime))
INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx], [createtime]) VALUES (7, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'1', CAST(0x0000AA1D01050FFB AS DateTime))
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  Table [dbo].[OpLog]    Script Date: 03/28/2019 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[createtime] [datetime] NULL,
	[beizhu] [nvarchar](200) NULL,
 CONSTRAINT [PK_OpLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OpLog] ON
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (1, N'admin', CAST(0x0000AA1B00E6186D AS DateTime), N'登陆成功')

GO
print 'Processed 100 total records'
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (101, N'admin', CAST(0x0000AA1C0103FA3C AS DateTime), N'登陆成功')
GO
print 'Processed 200 total records'
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (202, N'admin', CAST(0x0000AA1E00F15E53 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (203, N'admin', CAST(0x0000AA1E010BDD74 AS DateTime), N'登陆成功')
SET IDENTITY_INSERT [dbo].[OpLog] OFF
/****** Object:  Table [dbo].[ImgInfo]    Script Date: 03/28/2019 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImgInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[guige] [nvarchar](50) NULL,
	[changjia] [nvarchar](200) NULL,
	[pihao] [nvarchar](50) NULL,
	[createtime] [datetime] NULL,
	[beizhu] [nvarchar](50) NULL,
	[url] [nvarchar](500) NULL,
 CONSTRAINT [PK_ImgInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ImgInfo] ON
INSERT [dbo].[ImgInfo] ([id], [name], [guige], [changjia], [pihao], [createtime], [beizhu], [url]) VALUES (1, N'k', N'额外热图', N'又要人头比而分为', N'111', CAST(0x0000AA1E00F11075 AS DateTime), N'', N'/images/20190328/zuo8.jpg')
SET IDENTITY_INSERT [dbo].[ImgInfo] OFF
/****** Object:  Table [dbo].[BaseInfo]    Script Date: 03/28/2019 16:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[pinyin] [nvarchar](50) NULL,
	[guige] [nvarchar](50) NULL,
	[changjia] [nvarchar](200) NULL,
	[beizhu] [nvarchar](200) NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_BaseInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简拼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'pinyin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'guige'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'changjia'
GO
SET IDENTITY_INSERT [dbo].[BaseInfo] ON
INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu], [createtime]) VALUES (1, N'干吃面', N'GCM', N'一包', N'陕西西安干吃面', NULL, NULL)

SET IDENTITY_INSERT [dbo].[BaseInfo] OFF
/****** Object:  Default [DF_BaseInfo_createtime]    Script Date: 03/28/2019 16:33:17 ******/
ALTER TABLE [dbo].[BaseInfo] ADD  CONSTRAINT [DF_BaseInfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
/****** Object:  Default [DF_ImgInfo_createtime]    Script Date: 03/28/2019 16:33:17 ******/
ALTER TABLE [dbo].[ImgInfo] ADD  CONSTRAINT [DF_ImgInfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
/****** Object:  Default [DF_OpLog_createtime]    Script Date: 03/28/2019 16:33:17 ******/
ALTER TABLE [dbo].[OpLog] ADD  CONSTRAINT [DF_OpLog_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
/****** Object:  Default [DF_UserInfo_createtime]    Script Date: 03/28/2019 16:33:17 ******/
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
