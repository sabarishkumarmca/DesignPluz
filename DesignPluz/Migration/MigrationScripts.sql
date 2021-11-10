 USE [DesignPluz]
GO
ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_Addresses_Customers]
GO
ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [DF_Addresses_Primary]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 2021-11-10 20:25:08 ******/
DROP TABLE [dbo].[Genders]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2021-11-10 20:25:08 ******/
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[AddressTypes]    Script Date: 2021-11-10 20:25:08 ******/
DROP TABLE [dbo].[AddressTypes]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 2021-11-10 20:25:08 ******/
DROP TABLE [dbo].[Addresses]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 2021-11-10 20:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [varchar](150) NOT NULL,
	[AddressTypeId] [int] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[Primary] [bit] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AddressTypes]    Script Date: 2021-11-10 20:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AddressTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2021-11-10 20:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[mobilenumber] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[genderId] [int] NOT NULL,
	[createdon] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 2021-11-10 20:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AddressTypes] ON 

INSERT [dbo].[AddressTypes] ([id], [AddressType]) VALUES (1, N'Billing Address')
INSERT [dbo].[AddressTypes] ([id], [AddressType]) VALUES (2, N'Shipping Address')
SET IDENTITY_INSERT [dbo].[AddressTypes] OFF
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Gender]) VALUES (1, N'Male')
INSERT [dbo].[Genders] ([Id], [Gender]) VALUES (2, N'Female')
INSERT [dbo].[Genders] ([Id], [Gender]) VALUES (3, N'Trangender')
SET IDENTITY_INSERT [dbo].[Genders] OFF
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_Primary]  DEFAULT ((0)) FOR [Primary]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Customers]
GO
