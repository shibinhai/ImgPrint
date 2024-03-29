USE [PrintImg]
GO
/****** Object:  Table [dbo].[BaseInfo]    Script Date: 2019/3/27 20:36:15 ******/
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
 CONSTRAINT [PK_BaseInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImgInfo]    Script Date: 2019/3/27 20:36:15 ******/
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
	[url] [nvarchar](500) NULL,
	[beizhu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ImgInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpLog]    Script Date: 2019/3/27 20:36:15 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2019/3/27 20:36:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[userpwd] [nvarchar](50) NOT NULL,
	[qx] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BaseInfo] ON 

INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu]) VALUES (1, N'干吃面', N'GCM', N'一包', N'陕西西安干吃面', NULL)
INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu]) VALUES (2, N'冷饮', N'LY', N'一袋', N'陕西渭南', NULL)
INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu]) VALUES (3, N'但是', N'D', N'对方', N'顺丰大概', N'')
INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu]) VALUES (4, N'是的', N'SD', N'党反', N'分的高分', N'')
INSERT [dbo].[BaseInfo] ([id], [name], [pinyin], [guige], [changjia], [beizhu]) VALUES (5, N'分隔符', N'FGF', N'的观点', N'的法国队', N'')
SET IDENTITY_INSERT [dbo].[BaseInfo] OFF
SET IDENTITY_INSERT [dbo].[ImgInfo] ON 

INSERT [dbo].[ImgInfo] ([id], [name], [guige], [changjia], [pihao], [createtime], [url], [beizhu]) VALUES (7, N'd', N'对方', N'顺丰大概', N'二房东如果', CAST(0x0000AA1C014CE5F9 AS DateTime), N'\images\20190326\01251457f9ed73a84a0d304ff8abee.jpg', N'')
SET IDENTITY_INSERT [dbo].[ImgInfo] OFF
SET IDENTITY_INSERT [dbo].[OpLog] ON 

INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (1, N'admin', CAST(0x0000AA1B00E6186D AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (2, N'admin', CAST(0x0000AA1B0118D43E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (3, N'admin', CAST(0x0000AA1B0118FF4C AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (4, N'admin', CAST(0x0000AA1B0119D6F3 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (5, N'admin', CAST(0x0000AA1B011A7676 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (6, N'admin', CAST(0x0000AA1B011B032E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (7, N'admin', CAST(0x0000AA1B011B2259 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (8, N'admin', CAST(0x0000AA1B011B558B AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (9, N'admin', CAST(0x0000AA1B011B70F6 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (10, N'admin', CAST(0x0000AA1B011BF677 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (11, N'admin', CAST(0x0000AA1B011C0998 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (12, N'admin', CAST(0x0000AA1B01684671 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (13, N'admin', CAST(0x0000AA1B0169481E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (14, N'admin', CAST(0x0000AA1B0169BA40 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (15, N'admin', CAST(0x0000AA1B0169D4AF AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (16, N'admin', CAST(0x0000AA1B016A354B AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (17, N'admin', CAST(0x0000AA1B016B0D73 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (18, N'admin', CAST(0x0000AA1B016C62BC AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (19, N'admin', CAST(0x0000AA1B016CFDDD AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (20, N'admin', CAST(0x0000AA1B016D4E09 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (21, N'admin', CAST(0x0000AA1B016FBD6E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (22, N'admin', CAST(0x0000AA1B017266AD AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (23, N'admin', CAST(0x0000AA1B0172B8F0 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (24, N'admin', CAST(0x0000AA1B017396F4 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (25, N'admin', CAST(0x0000AA1B01758F67 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (26, N'admin', CAST(0x0000AA1B017EEB7B AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (27, N'admin', CAST(0x0000AA1C01451DBA AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (28, N'admin', CAST(0x0000AA1C014599B6 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (29, N'admin', CAST(0x0000AA1C0146670E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (30, N'admin', CAST(0x0000AA1C01486E4E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (31, N'admin', CAST(0x0000AA1C0148B919 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (32, N'admin', CAST(0x0000AA1C0148D991 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (33, N'admin', CAST(0x0000AA1C01492F14 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (34, N'admin', CAST(0x0000AA1C0149778D AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (35, N'admin', CAST(0x0000AA1C01498DB5 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (36, N'admin', CAST(0x0000AA1C014A9CFC AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (37, N'admin', CAST(0x0000AA1C014BAC0A AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (38, N'admin', CAST(0x0000AA1C014BEAE0 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (39, N'admin', CAST(0x0000AA1C014CA5FA AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (40, N'admin', CAST(0x0000AA1C01690AD9 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (41, N'admin', CAST(0x0000AA1C016C1A0B AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (42, N'admin', CAST(0x0000AA1C016D7F88 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (43, N'admin', CAST(0x0000AA1C016DCFE3 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (44, N'admin', CAST(0x0000AA1C016DE63E AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (45, N'admin', CAST(0x0000AA1C01703226 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (46, N'admin', CAST(0x0000AA1C01720DAC AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (47, N'admin', CAST(0x0000AA1C0172BE4C AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (48, N'admin', CAST(0x0000AA1C01736ED8 AS DateTime), N'登陆成功')
INSERT [dbo].[OpLog] ([id], [username], [createtime], [beizhu]) VALUES (49, N'admin', CAST(0x0000AA1C01739DAF AS DateTime), N'登陆成功')
SET IDENTITY_INSERT [dbo].[OpLog] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([id], [username], [userpwd], [qx]) VALUES (1, N'admin', N'1111', N'1')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
ALTER TABLE [dbo].[ImgInfo] ADD  CONSTRAINT [DF_ImgInfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
ALTER TABLE [dbo].[OpLog] ADD  CONSTRAINT [DF_OpLog_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简拼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'pinyin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'guige'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaseInfo', @level2type=N'COLUMN',@level2name=N'changjia'
GO
