/****** Object:  Database [Project-1-5]    Script Date: 21/12/2018 14:52:38 ******/
CREATE DATABASE [Project-1-5]
GO
USE [Project-1-5]
GO
/****** Object:  Schema [Hotel]    Script Date: 21/12/2018 14:52:40 ******/
CREATE SCHEMA [Hotel]
GO
/****** Object:  Table [Hotel].[Customers]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Customers](
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Zipcode] [int] NULL,
	[CardInfo] [nvarchar](20) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Employees]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Employees](
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nvarchar](100) NOT NULL,
	[Salary] [money] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Events]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Events](
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[EventsCustomers]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[EventsCustomers](
	[Id] [int] NOT NULL IDENTITY,
	[CustomerId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK_EventsCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Reservation]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Reservation](
	[Id] [int] NOT NULL IDENTITY,
	[CustomerId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[TotalCost] [money] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Rooms]    Script Date: 21/12/2018 14:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Rooms](
	[Id] [int] NOT NULL IDENTITY,
	[Cost] [money] NOT NULL,
	[Beds] [int] NOT NULL,
	[Reserved] [bit] NOT NULL,
	[RoomType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Hotel].[EventsCustomers] ADD  CONSTRAINT [DF_EventsCustomers_Paid]  DEFAULT ((0)) FOR [Paid]
GO
ALTER TABLE [Hotel].[Rooms] ADD  CONSTRAINT [DF_Rooms_Reserved]  DEFAULT ((0)) FOR [Reserved]
GO
ALTER TABLE [Hotel].[EventsCustomers]  WITH CHECK ADD  CONSTRAINT [FK_EventsCustomers_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Hotel].[Customers] ([Id]) on delete cascade
GO
ALTER TABLE [Hotel].[EventsCustomers] CHECK CONSTRAINT [FK_EventsCustomers_Customer]
GO
ALTER TABLE [Hotel].[EventsCustomers]  WITH CHECK ADD  CONSTRAINT [FK_EventsCustomers_Event] FOREIGN KEY([EventId])
REFERENCES [Hotel].[Events] ([Id]) on delete cascade
GO
ALTER TABLE [Hotel].[EventsCustomers] CHECK CONSTRAINT [FK_EventsCustomers_Event]
GO
ALTER TABLE [Hotel].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Hotel].[Customers] ([Id])
GO
ALTER TABLE [Hotel].[Reservation] CHECK CONSTRAINT [FK_Reservation_Customer]
GO
ALTER TABLE [Hotel].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room] FOREIGN KEY([RoomId])
REFERENCES [Hotel].[Rooms] ([Id])
GO
ALTER TABLE [Hotel].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room]
GO
