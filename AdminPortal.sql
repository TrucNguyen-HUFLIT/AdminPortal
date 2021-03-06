USE [AdminPortalDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/1/2021 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 6/1/2021 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/1/2021 10:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210507063045_CreateAdminPortalDB', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210507063509_Update_Required_AdminPortalDB', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (1, N'ngoctruc020100@gmail.com', N'2e33a9b0b06aa0a01ede70995674ee23', N'Truc', N'Nguyen', N'/img/avt-kh1.jpg', 1)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (2, N'cuba2610@gmail.com', N'148a0da9d3c3d3cca0e20c2fbb8c1ce5', N'Truc', N'Nguyen', N'/img/avt-kh1.jpg', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (3, N'bbridgett2@ibm.com', N'kDU8zS6Xf8', N'Bartel', N'Bridgett', N'https://robohash.org/inciduntatiure.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (4, N'hneave3@discovery.com', N'kCVars', N'Hort', N'Neave', N'https://robohash.org/reiciendisnihildolores.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (5, N'jwyard4@ning.com', N'UAT8C9vuZR4J', N'Jilli', N'Wyard', N'https://robohash.org/expeditanecessitatibusdoloribus.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (6, N'kdunbavin5@oracle.com', N'jYKBAyEfI', N'Kerwin', N'Dunbavin', N'https://robohash.org/sintreprehenderitsint.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (7, N'mfinnis6@buzzfeed.com', N'vzW4pZwFFXQ', N'Myrta', N'Finnis', N'https://robohash.org/maioresanimivel.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (8, N'kfarragher7@newyorker.com', N'JJKi22iKa', N'Kenton', N'Farragher', N'https://robohash.org/consequaturconsequunturtemporibus.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (9, N'ssanten8@epa.gov', N'2f11up0F', N'Sybilla', N'Santen', N'https://robohash.org/excepturisitquia.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (10, N'glademann9@friendfeed.com', N'Op8cOEo6', N'Gracia', N'Lademann', N'https://robohash.org/rerumeteligendi.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (11, N'astancliffea@rediff.com', N'P4f7tt', N'Alphard', N'Stancliffe', N'https://robohash.org/recusandaetemporaharum.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (12, N'pbarratb@rediff.com', N'v20NPh', N'Paulina', N'Barrat', N'https://robohash.org/quaeaccusamusfuga.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (13, N'srevenc@dropbox.com', N'uEU1o4', N'Stanislaus', N'Reven', N'https://robohash.org/recusandaevoluptassuscipit.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (14, N'nalexandred@github.com', N'rE2yw4o1', N'Norrie', N'Alexandre', N'https://robohash.org/nequefugiatrerum.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (15, N'kwhitehousee@dailymotion.com', N'Oz1OTC34EglU', N'Kelsy', N'Whitehouse', N'https://robohash.org/etodiorerum.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (16, N'srowlandsf@myspace.com', N'xabb9qpBO', N'Sissy', N'Rowlands', N'https://robohash.org/placeatnostrumad.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (17, N'acatfordg@admin.ch', N'0VsTX1yGJq', N'Adolphe', N'Catford', N'https://robohash.org/auteaveritatis.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (18, N'cbeath@discuz.net', N'FVpTsq1KnBB', N'Cedric', N'Beat', N'https://robohash.org/mollitiaautemearum.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (19, N'vstuckfordi@shutterfly.com', N'IU5bAHhlskV', N'Vaclav', N'Stuckford', N'https://robohash.org/praesentiumvoluptatemplaceat.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (20, N'dmalmarj@technorati.com', N'hdeBzW1C3bj', N'Dennie', N'Malmar', N'https://robohash.org/quiaminusut.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (21, N'jstarek@seesaa.net', N'ZTgi2WrI2Hv', N'Jeri', N'Stare', N'https://robohash.org/harumperferendisrepellat.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (22, N'jcauderliel@arizona.edu', N'lCjTw4WsXn', N'Jordan', N'Cauderlie', N'https://robohash.org/sednemoveritatis.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (23, N'nandrysm@harvard.edu', N'WwqGWnRgGW', N'Nesta', N'Andrys', N'https://robohash.org/excepturiinciduntaliquid.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (24, N'breamen@wordpress.com', N'AEtwyqvAJyKR', N'Birdie', N'Reame', N'https://robohash.org/possimusetpariatur.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (25, N'tgodleeo@cdc.gov', N'KhlkRiJq', N'Toinette', N'Godlee', N'https://robohash.org/etreiciendisalias.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (26, N'sholtp@macromedia.com', N'inmcYTA', N'Stace', N'Holt', N'https://robohash.org/nonaspernaturdolores.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (27, N'jklessmannq@deviantart.com', N'Nwo4GVSw', N'Joannes', N'Klessmann', N'https://robohash.org/necessitatibusmolestiaeut.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (28, N'rodwyerr@twitpic.com', N'MjvOczE', N'Reider', N'O''Dwyer', N'https://robohash.org/utnecessitatibusdistinctio.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (29, N'mlannens@miibeian.gov.cn', N'Gc7Z75IgUrIZ', N'Mordecai', N'Lannen', N'https://robohash.org/voluptasutdebitis.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (30, N'rmozzinit@msn.com', N'4qOpIfXYo', N'Rosita', N'Mozzini', N'https://robohash.org/illumenimsuscipit.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (31, N'bpawlettu@timesonline.co.uk', N'tEYX7H0', N'Billi', N'Pawlett', N'https://robohash.org/eiusautplaceat.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (32, N'gzecchettiv@youku.com', N'ybVfCFZWizF', N'Gracie', N'Zecchetti', N'https://robohash.org/consequaturmagniaut.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (33, N'tdumphreyw@elegantthemes.com', N'6L3aqAC4Cqt7', N'Theresina', N'Dumphrey', N'https://robohash.org/quaesintexpedita.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (34, N'afrippx@webnode.com', N'RjTJPeJdQIWd', N'Aubree', N'Fripp', N'https://robohash.org/saepeeosab.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (35, N'ktrodlery@cafepress.com', N'KRuZFdpyryT7', N'Karlotta', N'Trodler', N'https://robohash.org/quissedquibusdam.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (36, N'arummingz@squarespace.com', N'ZYu3iDvpN', N'Abbie', N'Rumming', N'https://robohash.org/quicorporisut.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (37, N'sherrema10@ucoz.ru', N'tiba5DAo', N'Serge', N'Herrema', N'https://robohash.org/quirerumquia.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (38, N'dkibbey11@usnews.com', N'5STV3Cqfb', N'Dav', N'Kibbey', N'https://robohash.org/mollitiaillumducimus.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (39, N'seam12@time.com', N'QCLfliU9IVZm', N'Scott', N'Eam', N'https://robohash.org/corporisperspiciatistotam.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (40, N'kfraser13@uol.com.br', N'uXXEbwgwsAP8', N'Karla', N'Fraser', N'https://robohash.org/estinventorecumque.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (41, N'dgunby14@dedecms.com', N'yGcEDGMR', N'Devin', N'Gunby', N'https://robohash.org/doloreetcommodi.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (42, N'ddoxey15@yelp.com', N'ah9MyfQ99ykR', N'Darn', N'Doxey', N'https://robohash.org/aliquamquivitae.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (43, N'abeagan16@arstechnica.com', N'3NNUi5fgaF', N'Audi', N'Beagan', N'https://robohash.org/sittemporafuga.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (44, N'nnapier17@slashdot.org', N'a5TulV9F', N'Nannette', N'Napier', N'https://robohash.org/saepedelenitised.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (45, N'wbillows18@ifeng.com', N'ujCJ4qxRe1H', N'Worth', N'Billows', N'https://robohash.org/maximerepellendusmolestiae.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (46, N'lbugbird19@unblog.fr', N'XzSPRhMAp0', N'Ludvig', N'Bugbird', N'https://robohash.org/possimusminimaat.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (47, N'gcharville1a@sciencedirect.com', N'Cec1Ck6Qi', N'Garnette', N'Charville', N'https://robohash.org/eosfugarerum.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (48, N'dhriinchenko1b@chron.com', N'zXrwQOP3wF', N'Devora', N'Hriinchenko', N'https://robohash.org/undesedsit.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (49, N'nrolfi1c@apache.org', N'fSx687rUmt', N'Natalee', N'Rolfi', N'https://robohash.org/sedvelitpariatur.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (50, N'mlesek1d@house.gov', N'k4QgRWhWi', N'Morley', N'Lesek', N'https://robohash.org/rerumdoloremest.png?size=150x150&set=set1', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (87, N'truc@00000', N'408370ada7431835d7bcedd4f428388c', N'Truc020100', N'Nguyen', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (110, N'aaa@gmail.com', N'91f42b6b56ad751a11bb343037fc3f19', N'aaa', N'aaa', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (111, N'aaa@gmail.com1', N'91f42b6b56ad751a11bb343037fc3f19', N'aaa', N'aaa', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (112, N'ngoctruc020100@gmail.com12', N'6ea47f9209ef5278616c80004cab7301', N'Truc020100', N'Nguyen', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (113, N'ngoctruc020100@gmail.com14', N'6ea47f9209ef5278616c80004cab7301', N'a', N'Nguyen', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (114, N'ngoctruc020100@gmail.com15', N'6ea47f9209ef5278616c80004cab7301', N'Truc020100', N'Nguyen', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (115, N'ngoctruc020100@gmail.com16', N'6ea47f9209ef5278616c80004cab7301', N'Truc020100', N'Nguyen', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (125, N'ngoctruc0201@gmail.com', N'794fcb389bca8b62256262f35554181a', N'a', N'a', N'/img/avatar-default-icon.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [RoleId]) VALUES (127, N'a@gmail.com', N'794fcb389bca8b62256262f35554181a', N'a', N'a', N'/img/avt-kh1.jpg', 2)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF__Accounts__Email__48CFD27E]  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF__Accounts__Passwo__47DBAE45]  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles_RoleId]
GO
