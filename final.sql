USE [master]
GO
/****** Object:  Database [MVCFinalDB]    Script Date: 5/9/2016 5:47:51 PM ******/
CREATE DATABASE [MVCFinalDB] ON  PRIMARY 
( NAME = N'MVCFinalDB', FILENAME = N'H:\MSSQLSERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MVCFinalDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MVCFinalDB_log', FILENAME = N'H:\MSSQLSERVER\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MVCFinalDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MVCFinalDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVCFinalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVCFinalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVCFinalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVCFinalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVCFinalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVCFinalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVCFinalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVCFinalDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MVCFinalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVCFinalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVCFinalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVCFinalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVCFinalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVCFinalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVCFinalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVCFinalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVCFinalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVCFinalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVCFinalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVCFinalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVCFinalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVCFinalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVCFinalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVCFinalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVCFinalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MVCFinalDB] SET  MULTI_USER 
GO
ALTER DATABASE [MVCFinalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVCFinalDB] SET DB_CHAINING OFF 
GO
USE [MVCFinalDB]
GO
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RoomNo] [int] NOT NULL,
	[StratDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[RoomFlag] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseAssignToTeacher]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignToTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[CourseAssign] [int] NOT NULL,
 CONSTRAINT [PK_CourseAssignToTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Semester] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Date]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Date](
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnrollInACourse]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollInACourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[Date] [datetime] NULL,
	[EnrollInACourse] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[Grade] [nvarchar](5) NULL,
	[StudentResult] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Date] [datetime2](2) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[RegNo] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Designation] [int] NOT NULL,
	[Department] [int] NOT NULL,
	[CreditToBeTaken] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[CourseView]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








create view [dbo].[CourseView] as
select c.Name as Name, c.Code as Code  , c.Semester as SEMESTER, c.DepartmentId as DepartmentId, ct.TeacherId, t.Name as TeachersName from Courses c full outer join CourseAssignToTeacher ct on c.id=ct.CourseId left join Teachers t on ct.TeacherId=t.Id


where ct.CourseAssign=1;






GO
/****** Object:  View [dbo].[Schedule]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create view [dbo].[Schedule] AS
select c.Code as CODE, c.Name as NAME, c.DepartmentId as DepartmentId, r.RoomNo as RoomNo, al.EndDate as ENDDATE,al.StratDate as STARTDATE, al.RoomNo as ROOM FROM Courses c left outer join AllocateClassRoom al on al.CourseId=c.Id  left outer join Rooms r on r.Id=al.RoomNo

where al.RoomFlag=1

GO
/****** Object:  View [dbo].[Schedule1]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Schedule1] AS
select c.Code as CODE, c.Name as NAME, c.DepartmentId as DepartmentId, r.RoomNo as RoomNo, al.EndDate as ENDDATE,al.StratDate as STARTDATE, al.RoomNo as ROOM FROM Courses c full outer join AllocateClassRoom al on al.CourseId=c.Id  inner join Rooms r on r.Id=al.RoomNo


GO
/****** Object:  View [dbo].[Schedule2]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Schedule2] AS
select c.Code as CODE, c.Name as NAME, c.DepartmentId as DepartmentId, r.RoomNo as RoomNo, al.EndDate as ENDDATE,al.StratDate as STARTDATE, al.RoomNo as ROOM FROM Courses c full outer join AllocateClassRoom al on al.CourseId=c.Id  left outer join Rooms r on r.Id=al.RoomNo


GO
/****** Object:  View [dbo].[Schedule3]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Schedule3] AS
select c.Code as CODE, c.Name as NAME, c.DepartmentId as DepartmentId, r.RoomNo as RoomNo, al.EndDate as ENDDATE,al.StratDate as STARTDATE, al.RoomNo as ROOM FROM Courses c full outer join AllocateClassRoom al on al.CourseId=c.Id  full outer join Rooms r on r.Id=al.RoomNo


GO
/****** Object:  View [dbo].[Schedule4]    Script Date: 5/9/2016 5:47:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Schedule4] AS
select c.Code as CODE, c.Name as NAME, c.DepartmentId as DepartmentId, r.RoomNo as RoomNo, al.EndDate as ENDDATE,al.StratDate as STARTDATE, al.RoomNo as ROOM FROM Courses c left outer join AllocateClassRoom al on al.CourseId=c.Id  left outer join Rooms r on r.Id=al.RoomNo


GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [RoomNo], [StratDate], [EndDate], [RoomFlag], [CourseId]) VALUES (1, 1, 2, CAST(0x0000A5FE00C46170 AS DateTime), CAST(0x0000A5F7002A9270 AS DateTime), 0, 3)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [RoomNo], [StratDate], [EndDate], [RoomFlag], [CourseId]) VALUES (2, 1, 2, CAST(0x0000A5FF007CF830 AS DateTime), CAST(0x0000A5FF007779F0 AS DateTime), 0, 3)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [RoomNo], [StratDate], [EndDate], [RoomFlag], [CourseId]) VALUES (3, 1, 1, CAST(0x0000A5FD0023B4A0 AS DateTime), CAST(0x0000A5FD00E975A0 AS DateTime), 0, 1)
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] ON 

INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (2, 1, 5, 1, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (3, 1, 5, 1, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (4, 1, 8, 6, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (5, 1, 5, 3, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (6, 1, 5, 6, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (7, 1, 5, 7, 0)
INSERT [dbo].[CourseAssignToTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [CourseAssign]) VALUES (8, 1, 5, 7, 0)
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (1, N'Algorithm', N'00111', CAST(3.00 AS Decimal(18, 2)), N'skdjkj', 1, N'1')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (2, N'DATA STRUCTURE', N'00223', CAST(3.00 AS Decimal(18, 2)), N'DJSKJKJSF', 2, N'2')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (3, N'DATABASE', N'02222', CAST(3.00 AS Decimal(18, 2)), N'ksdjkkjds', 1, N'2')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (4, N'MATHS', N'012MH', CAST(3.00 AS Decimal(18, 2)), N'SLJDKLJ', 3, N'1')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (6, N'Software engineering Principles ', N'0122SRE', CAST(3.00 AS Decimal(18, 2)), N'256', 1, N'1')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (7, N'JAVA', N'01222', CAST(5.00 AS Decimal(18, 2)), N'hskfklasjf.smmslkafsk.,,saljdl', 1, N'1')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (8, N'DHSAJDHJAH', N'0122200', CAST(3.00 AS Decimal(18, 2)), N'SASF', 4, N'1')
INSERT [dbo].[Courses] ([Id], [Name], [Code], [Credit], [Description], [DepartmentId], [Semester]) VALUES (9, N'Introduction To English Literature ', N'ENG0012', CAST(3.00 AS Decimal(18, 2)), N'hirahajh', 6, N'1')
SET IDENTITY_INSERT [dbo].[Courses] OFF
INSERT [dbo].[Date] ([Date]) VALUES (CAST(0x00009E8100000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science And Software Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (3, N'EEE', N'Electrical And Electronic Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (4, N'SE', N'Software Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (5, N'0122SE', N'Advance Computer Network')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (6, N'ENG001', N'English Literature')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (1, N'Faculty ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (2, N'Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (3, N'Part time')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollInACourse] ON 

INSERT [dbo].[EnrollInACourse] ([Id], [StudentId], [CourseId], [Date], [EnrollInACourse]) VALUES (1, 4, 8, CAST(0x0000A5F4002932E0 AS DateTime), 0)
INSERT [dbo].[EnrollInACourse] ([Id], [StudentId], [CourseId], [Date], [EnrollInACourse]) VALUES (2, 2, 1, CAST(0x0000A5FC00B12790 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[EnrollInACourse] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (1, N'R-2001')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (2, N'A-2201')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (3, N'B-2256')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (4, N'R-2007')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (5, N'R-2569')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([Id], [Name]) VALUES (1, N'one')
SET IDENTITY_INSERT [dbo].[Semesters] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Department], [RegNo]) VALUES (1, N'Mr. A', N'a@a.com', N'0178687', CAST(0x020000006E390B0000 AS DateTime2), N'Dhaka', N'CSE', N'1')
INSERT [dbo].[Students] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Department], [RegNo]) VALUES (2, N'Mr. B', N'b@b.com', N'0178687', CAST(0x020000006E390B0000 AS DateTime2), N'Dhaka', N'CSE', N'2')
INSERT [dbo].[Students] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [Department], [RegNo]) VALUES (4, N'kana', N'hsjhJKA@HH.COM', N'65656565', CAST(0x02E0E60B503B0B0000 AS DateTime2), N'SFSFSF', N'SE', N'SE-2016-001')
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [Designation], [Department], [CreditToBeTaken]) VALUES (5, N'hira', N'kajkj', N'jkjkj', N'323232', 2, 1, NULL)
INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [Designation], [Department], [CreditToBeTaken]) VALUES (7, N'siam', N'annkj', N'jkj', N'3535', 2, 2, NULL)
INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [Designation], [Department], [CreditToBeTaken]) VALUES (8, N'hira', N'iuhia', N'hira@gamil.com', N'0171192762', 2, 1, NULL)
INSERT [dbo].[Teachers] ([Id], [Name], [Address], [Email], [ContactNo], [Designation], [Department], [CreditToBeTaken]) VALUES (9, N'Masud', N'Hazaribag', N'masud@gmail.com', N'021111', 2, 6, CAST(10 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Teachers] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Courses]    Script Date: 5/9/2016 5:47:51 PM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [IX_Courses] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Courses_1]    Script Date: 5/9/2016 5:47:51 PM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [IX_Courses_1] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Departments]    Script Date: 5/9/2016 5:47:51 PM ******/
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [IX_Departments] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teachers]    Script Date: 5/9/2016 5:47:51 PM ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [IX_Teachers] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_AllocateClassRoom] FOREIGN KEY([Id])
REFERENCES [dbo].[AllocateClassRoom] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_AllocateClassRoom]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Courses]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Departments]
GO
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_CourseAssignToTeacher1] FOREIGN KEY([Id])
REFERENCES [dbo].[CourseAssignToTeacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_CourseAssignToTeacher1]
GO
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_CourseAssignToTeacher2] FOREIGN KEY([Id])
REFERENCES [dbo].[CourseAssignToTeacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_CourseAssignToTeacher2]
GO
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_Courses]
GO
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_Teachers]
GO
USE [master]
GO
ALTER DATABASE [MVCFinalDB] SET  READ_WRITE 
GO
