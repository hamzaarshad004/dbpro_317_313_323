USE [DB45]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalenderMonth]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalenderMonth](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Month] [datetime] NOT NULL,
 CONSTRAINT [PK_CalenderMonth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeacher](
	[StaffId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_CourseTeacher] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyAttendanceStaff]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyAttendanceStaff](
	[DateId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[AttendanceStatus] [varchar](15) NOT NULL,
 CONSTRAINT [PK_DailyAttendanceStaff] PRIMARY KEY CLUSTERED 
(
	[DateId] ASC,
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyAttendanceStudent]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyAttendanceStudent](
	[DateId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[AttendanceStatus] [varchar](15) NOT NULL,
 CONSTRAINT [PK_DailyAttendanceStudent] PRIMARY KEY CLUSTERED 
(
	[DateId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DateKeeper]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DateKeeper](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DateKeeper] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[ExamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamBySubject]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamBySubject](
	[ExamId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ExamBySubject] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institute]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institute](
	[Name] [varchar](30) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Institute] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonthlyReports]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyReports](
	[MonthId] [int] NOT NULL,
	[Expenses] [float] NOT NULL,
	[Revenue] [float] NOT NULL,
 CONSTRAINT [PK_MonthlyReports] PRIMARY KEY CLUSTERED 
(
	[MonthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FatherName] [varchar](30) NOT NULL,
	[Cnic] [varchar](15) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[ContactNo] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[AdmissionStart] [datetime] NOT NULL,
	[AdmissionEnd] [datetime] NOT NULL,
	[ClassesStart] [datetime] NOT NULL,
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ExamId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC,
	[SubjectId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[SectionName] [char](2) NOT NULL,
	[Batch] [int] NOT NULL,
	[TotalStudents] [int] NULL,
	[ProgramId] [int] NOT NULL,
 CONSTRAINT [PK_Section_1] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] NOT NULL,
	[Designation] [varchar](30) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[MonthlySalary] [float] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffFine]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffFine](
	[DateId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[FineAmount] [int] NOT NULL,
 CONSTRAINT [PK_StaffFine] PRIMARY KEY CLUSTERED 
(
	[DateId] ASC,
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] NOT NULL,
	[Batch] [int] NOT NULL,
	[RollNo] [varchar](30) NOT NULL,
	[MonthlyFee] [float] NOT NULL,
	[AdmissionDate] [datetime] NOT NULL,
	[ProgramId] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentFine]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentFine](
	[DateId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[FineAmount] [int] NOT NULL,
 CONSTRAINT [PK_StudentFine] PRIMARY KEY CLUSTERED 
(
	[DateId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSection]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSection](
	[SectionId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentSection] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubjects]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubjects](
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_StudentSubjects] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[ProgramId] [int] NOT NULL,
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 5/5/2019 12:51:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[SectionId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Day] [varchar](20) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[timetableId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC,
	[SubjectId] ASC,
	[Day] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201904271154005_InitialCreate', N'LMS.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE4B8117D0F907F10F49404DE962F99C1C468EFC2DBB61323BE61DAB3C8DB802DB1DBC2489456A2BC3682FDB23CEC27ED2FA42851375E24AA5BEE6E2F0618B4C8E2A962B148168B45FFFEBFDFA63FBC8481F58C93D48FC8997D3439B42D4CDCC8F3C9EACCCEE8F2BB4FF60FDFFFF94FD34B2F7CB17E2AE94E181DB424E999FD44697CEA38A9FB8443944E42DF4DA2345AD2891B850EF222E7F8F0F01FCED1918301C2062CCB9A7ECE08F5439C7FC0E72C222E8E698682DBC8C341CACBA1669EA35A7728C4698C5C7C66DFDCCE2705956D9D073E0209E63858DA162224A288827CA75F523CA7494456F3180A50F0F81A63A05BA220C55CEED39ADCB40B87C7AC0B4EDDB08472B39446E140C0A313AE13476CBE9666ED4A67A0B54BD02E7D65BDCE3577665F7B382FFA1C05A00091E1E92C4818F1997D5BB1384FE33B4C2765C34901799500DC2F51F26DD2443CB08CDB1D5436743C3964FF0EAC5916D02CC16704673441C181F5902D02DFFD377E7D8CBE61727672B4589E7CFAF01179271FFF8E4F3E347B0A7D05BA5601143D24518C13900D2FABFEDB96D36EE7880DAB668D368556C096603AD8D62D7AB9C164459F60A21C7FB2AD2BFF057B650937AE2FC487D9038D6892C1E75D16046811E0AADEE9E4C9FEEFE07AFCE1E3285CEFD0B3BFCA875EE00F13278179F51907796DFAE4C7C5F46A8DF7574E76954421FB6EDB5751FB751E6589CB3A1369491E51B2C2B42DDDD4A98DD7C8A419D4F8665DA2EEBF69334965F35692B20EAD33134A16DB9E0DA5BC6FCBD7D8E2CEE318062F372DA6912E83AB37A989D0EAC082BADA548E4C4D854017FEC82BDF6588FC6084A5CF800B781B4B3F0971D5CB1F2330344406CBFC80D21466BEF72F943E75880E3F47107D8EDD2C01839C5314C66FCEEDE12922F82E0B17CCCEB7C76BB4A179FC25BA422E8D924BC25A6D8C7713B9DFA28C5E12EF0251FC85BA2520FB7CF443738051C439775D9CA65760CCD89B45E04C9780D7849E1C0F86630BD3AE5D8F5980FC50ED7B084BE8D792B4F63FD414920FA22153F9215DA2DE442B9F98895A92EA452D287A45E564434565606692724ABDA03941AF9C05D5689E5D3E42E3BB7639ECFEFB769B6DDEBAB5A0A1C639AC90F89F98E0049631EF01518A13528F80C9BAB10B67211F3EC6F4CDF7A69CD34F28C8C666B5D66CC81781F167430EBBFFB32117138A9F7D8F792506079E9218E08DE8D567A9FE392748B6EDE9D0EAE6B6996F670DD04D97F3348D5C3F9F058A50170F54B4E5071FCEEA8F5A14BD11231FD03130749F6D7950027DB345A3BA271738C0145BE76E110A9CA1D4459EAC46E8903740B072475508564740DAC2FD4DE209968E13D608B143500A33D527549E163E71FD1805BD5A125A1A6E61ACEF150FB1E602C7983086BD9A3061AE0E7830012A3EC2A0F46968EA342CAEDB10355EAB6ECCFB5CD87ADCA538C4566CB2C777D6D825F7DFDEC430BB35B605E3EC56898900DAE0DD2E0C949F554C0D403CB8EC9B810A27268D8172976A2B06DAD6D80E0CB4AD927767A0C511D574FC85F3EABE9967FBA0BCFD6DBD535D3BB0CD963EF6CC340BDF13DA50688113D93C2F16AC12BF50C5E10CE4E4E7B394BBBAA28930F039A6ED904DEDEF2AFD50A71B4434A22EC0DAD07A40F9B59F04244DA801C295B1BC4EE9B8173100B68CBB75C2F2B55F806DD8808CDDBCFE6C10EA2F4945E3343A7D543DABAC413272A3C34203476110E2E2D5EEB88152747159593126BEF0106FB8D1313E181D0AEAF15C354A2A3B33BA964AD3ECD792CA211BE2926DA425C17DD268A9ECCCE85AE236DAAF24855330C02DD84845ED2D7CA4C956463AAADDA6AA9B3A4536142F983A9AB4A9E92D8A639FAC1A6954BCC49A173954B3EFE6C3938CC202C3715345AE51256DC58946095A61A1165883A4577E92D20B44D102B138CFCC0B2532E5DEAA59FE4B96CDED531EC4721F28A9D96F1EBDAB2FEB5B7BACEC84F0B657D0B390793279F85C31EEEAE6164B6743014A1411FB59146421D13B56FAD6C5BD5DB37D5122234C1D417EC97192B424B9B76D951B0D883C19361C9CCA5F597F80F4103A3597DE6653D13A0F548F5206A49A28BA20D5CE064CE7B8180D92E80B0E1FA35E84B799473C01A509C08B066234721824B0469D396A3BCDA489D9AE31471472499A9042D500299B19232D219B156BE16934AAA630E720E78834D1E55A736445B648135A51BD06B64266B1CE1C559150D20456549B63D7D925E2E2B9C73B95F6843278AB2A0EAF9BED551A8CB75909C7D9EA1A77F44DA046F1402C7E0B2F81F1F2BDB422ED096EB01515B18ACDAC4883A15F695AB7DAED85A6F32A5E8FD9BAAA6E2DE65D57F57ABC61B6FAA616211DDC44928A7B7580130E6A537E68EA7F04239DA20A12DB2AD5081BF96B4A7138610493F9CFC12CF0315BB64B825B44FC254E69919E611F1F1E1D0BEF69F6E76D8B93A65EA03874EA1EB8B4C76C0B9956E41925EE134AE4BC870DDE7FD4A05248F99A78F8E5CCFE6FDEEA348F4EB05F79F181759D7E21FECF19543C2619B67E95F338C7C9873778815109FAEBBB78DA60AEF2EBFF7C2D9A1E58F7094CA753EB5050F43AC3DF7EF030489AA2E906D2ACFD0CE2FDCEB6D69B0325AA305BD67F62B0F0E928CF0B4A29FF12A297BF0E154DF984602344C53381B1F04651A1EE19C03A58DA27001E7CD2FC09C0B0CEAA9F04AC239AF639804F8683898F01CC97A1B2E50EF721C541691B4B52AEE7DE64EA8D322B77BD374939D71B4D7439AF7A00DCA8B9D39BB928EF2C2779B4AD5391723C1AF62EEDFECDF38CF725B5B876DA779B51BCCD24E28E8BA33F54EEF01E64BB29B277769F21BC6D5BD3457EF73CCD72581EF09E191BDFE6779FEDBB6D63D30588F7DCD806E5F4EE99ADED6AFFDCB1A5196FA13BCFD095938D343738AA28725F066E117287E3FF220223283CCAE2E1A43AE5AB2B5DB587614DA267AACF3513194B1347E22B5174B31DD657BEE1777696D374B3D5646876F1E6EB7F276F4ED3CD5B93F7B88BDC6165E6A12A9FBB671DEB4A937A4FB9C2AD9EF4A4A6F7F9AC9DD7F1EF29357814A5B4668FE676F9FD64028FA29231A7CE80CC5FF9A218F6CEC6DF5484FD3BF5573504FB0B8B04BBAD5DB3A2B926CBA8DCBC05894A122142738B29F2604B3D4FA8BF442E856A1680CE5F7EE7413D760DB2C0DE35B9CF689C51E8320E17412BE0C59C802EFE797A735BE6E97DCCBED231BA0062FA2C707F4F7ECCFCC0ABE4BE52C4843410CCBBE0E15E369694857D57AF15D25D440C81B8FA2AA7E81187710060E93D99A367BC8E6C607E377885DCD73A02A803E91F88B6DAA7173E5A25284C3946DD1E3EC186BDF0E5FBFF03AF5ED0875A540000, N'6.2.0-61023')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3bab895b-451b-47bc-acee-72d2bd89689e', N'hamzaarshad004@gmail.coma', 0, N'AOcIxuRUesuY0HcwBpeUfgpxI42zh16GxRCLqxeDX0tbVqzFcjNsV4c8RkHyZf5VIw==', N'183b99f2-0539-42c3-9ca9-54f0f212c9b3', NULL, 0, 0, NULL, 1, 0, N'hamzaarshad004@gmail.coma')
INSERT [dbo].[DailyAttendanceStaff] ([DateId], [StaffId], [AttendanceStatus]) VALUES (1, 4, N'Absent')
INSERT [dbo].[DailyAttendanceStaff] ([DateId], [StaffId], [AttendanceStatus]) VALUES (1, 1006, N'Present')
INSERT [dbo].[DailyAttendanceStudent] ([DateId], [StudentId], [AttendanceStatus]) VALUES (1, 1002, N'Absent')
INSERT [dbo].[DailyAttendanceStudent] ([DateId], [StudentId], [AttendanceStatus]) VALUES (1, 1005, N'Present')
SET IDENTITY_INSERT [dbo].[DateKeeper] ON 

INSERT [dbo].[DateKeeper] ([Id], [CurrentDate]) VALUES (1, CAST(N'2019-05-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DateKeeper] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (2, N'Hamza', N'Hamza', N'352023737226', N'M', N'253213', N'021')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (3, N'Hamza', N'Hamza', N'352023737226', N'M', N'253213', N'021')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (4, N'Hamza S', N'Hamza A', N'134325', N'M', N'42452', N'3215')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (5, N'Hamza', N'Arshad', N'125323', N'M', N'sdfsd 542', N'026542')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1002, N'Hamza', N'A', N'1663252', N'M', N'8451 wd ', N'051063')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1003, N'Huma', N'Usman', N'562', N'F', N'sdsd 45', N'05122')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1004, N'Hamza', N'Usman', N'456', N'M', N'562', N'0561')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1005, N'Hamza', N'Usman', N'456', N'M', N'562', N'0561')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1006, N'Hamza Arshad', N'ads', N'1124552', N'M', N'54sf4 dssdc', N'1262')
INSERT [dbo].[Person] ([PersonId], [Name], [FatherName], [Cnic], [Gender], [Address], [ContactNo]) VALUES (1007, N'Hamza', N'dsfd', N'sdffv', N'M', N'dsffb', N'df')
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Program] ON 

INSERT [dbo].[Program] ([ProgramId], [Name], [AdmissionStart], [AdmissionEnd], [ClassesStart]) VALUES (2, N'CSE', CAST(N'2000-04-10T00:00:00.000' AS DateTime), CAST(N'2000-01-02T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Program] OFF
INSERT [dbo].[Staff] ([StaffId], [Designation], [HireDate], [MonthlySalary]) VALUES (4, N'Hello', CAST(N'1988-02-04T00:00:00.000' AS DateTime), 10004)
INSERT [dbo].[Staff] ([StaffId], [Designation], [HireDate], [MonthlySalary]) VALUES (1006, N'Professor', CAST(N'2009-02-03T00:00:00.000' AS DateTime), 1200)
INSERT [dbo].[Student] ([StudentId], [Batch], [RollNo], [MonthlyFee], [AdmissionDate], [ProgramId]) VALUES (5, 2016, N'1234', 12000, CAST(N'2018-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student] ([StudentId], [Batch], [RollNo], [MonthlyFee], [AdmissionDate], [ProgramId]) VALUES (1002, 16, N'123', 2000, CAST(N'2019-05-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student] ([StudentId], [Batch], [RollNo], [MonthlyFee], [AdmissionDate], [ProgramId]) VALUES (1003, 16, N'134', 52200, CAST(N'1999-01-02T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student] ([StudentId], [Batch], [RollNo], [MonthlyFee], [AdmissionDate], [ProgramId]) VALUES (1005, 16, N'5196', 1224, CAST(N'1999-02-02T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student] ([StudentId], [Batch], [RollNo], [MonthlyFee], [AdmissionDate], [ProgramId]) VALUES (1007, 12, N'sdv', 123, CAST(N'2019-05-23T00:00:00.000' AS DateTime), 2)
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseTeacher_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK_CourseTeacher_Staff]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseTeacher_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK_CourseTeacher_Subjects]
GO
ALTER TABLE [dbo].[DailyAttendanceStaff]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceStaff_DateKeeper] FOREIGN KEY([DateId])
REFERENCES [dbo].[DateKeeper] ([Id])
GO
ALTER TABLE [dbo].[DailyAttendanceStaff] CHECK CONSTRAINT [FK_DailyAttendanceStaff_DateKeeper]
GO
ALTER TABLE [dbo].[DailyAttendanceStaff]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceStaff_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[DailyAttendanceStaff] CHECK CONSTRAINT [FK_DailyAttendanceStaff_Staff]
GO
ALTER TABLE [dbo].[DailyAttendanceStudent]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceStudent_DateKeeper] FOREIGN KEY([DateId])
REFERENCES [dbo].[DateKeeper] ([Id])
GO
ALTER TABLE [dbo].[DailyAttendanceStudent] CHECK CONSTRAINT [FK_DailyAttendanceStudent_DateKeeper]
GO
ALTER TABLE [dbo].[DailyAttendanceStudent]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceStudent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[DailyAttendanceStudent] CHECK CONSTRAINT [FK_DailyAttendanceStudent_Student]
GO
ALTER TABLE [dbo].[ExamBySubject]  WITH CHECK ADD  CONSTRAINT [FK_ExamBySubject_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([ExamId])
GO
ALTER TABLE [dbo].[ExamBySubject] CHECK CONSTRAINT [FK_ExamBySubject_Exam]
GO
ALTER TABLE [dbo].[ExamBySubject]  WITH CHECK ADD  CONSTRAINT [FK_ExamBySubject_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[ExamBySubject] CHECK CONSTRAINT [FK_ExamBySubject_Subjects]
GO
ALTER TABLE [dbo].[MonthlyReports]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyReports_CalenderMonth] FOREIGN KEY([MonthId])
REFERENCES [dbo].[CalenderMonth] ([Id])
GO
ALTER TABLE [dbo].[MonthlyReports] CHECK CONSTRAINT [FK_MonthlyReports_CalenderMonth]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([ExamId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Exam]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Student]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Subjects]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Program]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Person] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Person]
GO
ALTER TABLE [dbo].[StaffFine]  WITH CHECK ADD  CONSTRAINT [FK_StaffFine_DateKeeper] FOREIGN KEY([DateId])
REFERENCES [dbo].[DateKeeper] ([Id])
GO
ALTER TABLE [dbo].[StaffFine] CHECK CONSTRAINT [FK_StaffFine_DateKeeper]
GO
ALTER TABLE [dbo].[StaffFine]  WITH CHECK ADD  CONSTRAINT [FK_StaffFine_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[StaffFine] CHECK CONSTRAINT [FK_StaffFine_Staff]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Program]
GO
ALTER TABLE [dbo].[StudentFine]  WITH CHECK ADD  CONSTRAINT [FK_StudentFine_DateKeeper] FOREIGN KEY([DateId])
REFERENCES [dbo].[DateKeeper] ([Id])
GO
ALTER TABLE [dbo].[StudentFine] CHECK CONSTRAINT [FK_StudentFine_DateKeeper]
GO
ALTER TABLE [dbo].[StudentFine]  WITH CHECK ADD  CONSTRAINT [FK_StudentFine_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentFine] CHECK CONSTRAINT [FK_StudentFine_Student]
GO
ALTER TABLE [dbo].[StudentSection]  WITH CHECK ADD  CONSTRAINT [FK_StudentSection_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Section] ([SectionId])
GO
ALTER TABLE [dbo].[StudentSection] CHECK CONSTRAINT [FK_StudentSection_Section]
GO
ALTER TABLE [dbo].[StudentSection]  WITH CHECK ADD  CONSTRAINT [FK_StudentSection_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[StudentSection] CHECK CONSTRAINT [FK_StudentSection_Student]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Program]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Section] ([SectionId])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Section]
GO
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Subjects]
GO
