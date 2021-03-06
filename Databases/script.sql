USE [TravelAgencyDB]
GO
/****** Object:  Table [dbo].[Briefcase]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Briefcase](
	[id] [int] NOT NULL,
	[name] [varchar](45) NULL,
	[description] [varchar](45) NULL,
	[price] [float] NULL,
	[Travels_id] [int] NOT NULL,
	[city_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Briefcase_has_Services]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Briefcase_has_Services](
	[Briefcase_id] [int] NOT NULL,
	[Services_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Briefcase_id] ASC,
	[Services_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](45) NULL,
	[description] [varchar](45) NULL,
	[Department_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[client]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](50) NULL,
	[email] [varchar](45) NULL,
	[phone] [varchar](45) NULL,
	[gender] [char](1) NULL,
	[address] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[client_has_Travels]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_has_Travels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NOT NULL,
	[Travels_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](45) NULL,
	[description] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](45) NULL,
	[description] [varchar](45) NULL,
	[Country_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](45) NOT NULL,
	[descripcion] [varchar](45) NULL,
	[image] [varchar](max) NULL,
	[ServiceType_id] [int] NOT NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceType](
	[id] [int] NOT NULL,
	[name] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Travels]    Script Date: 7/2/2021 2:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[originCity_id] [int] NOT NULL,
	[arrivalCity_id] [int] NOT NULL,
	[briefcase_id] [int] NOT NULL,
 CONSTRAINT [PK__Travels__3213E83FB339EA98] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (1, N'Manizales', N'Lo mejor de colombia', 1)
INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (2, N'Medellin', NULL, 3)
INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (3, N'Pereira', NULL, 2)
INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (4, N'Santa rosa del cabal', NULL, 2)
INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (5, N'Neira', NULL, 1)
INSERT [dbo].[City] ([id], [name], [description], [Department_id]) VALUES (7, N'Bogota', NULL, 2)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [description]) VALUES (1, N'Colombia', N'Polombia')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([id], [name], [description], [Country_id]) VALUES (1, N'Caldas', N'ciudad del cafe', 1)
INSERT [dbo].[Department] ([id], [name], [description], [Country_id]) VALUES (2, N'Risaralda', N'pereiranos', 1)
INSERT [dbo].[Department] ([id], [name], [description], [Country_id]) VALUES (3, N'Antioquia', N'paisas', 1)
SET IDENTITY_INSERT [dbo].[Department] OFF
ALTER TABLE [dbo].[Briefcase]  WITH CHECK ADD FOREIGN KEY([city_id])
REFERENCES [dbo].[City] ([id])
GO
ALTER TABLE [dbo].[Briefcase_has_Services]  WITH CHECK ADD FOREIGN KEY([Briefcase_id])
REFERENCES [dbo].[Briefcase] ([id])
GO
ALTER TABLE [dbo].[Briefcase_has_Services]  WITH CHECK ADD FOREIGN KEY([Services_id])
REFERENCES [dbo].[Services] ([id])
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([Department_id])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[client_has_Travels]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([id])
GO
ALTER TABLE [dbo].[client_has_Travels]  WITH CHECK ADD  CONSTRAINT [FK__client_ha__Trave__398D8EEE] FOREIGN KEY([Travels_id])
REFERENCES [dbo].[Travels] ([id])
GO
ALTER TABLE [dbo].[client_has_Travels] CHECK CONSTRAINT [FK__client_ha__Trave__398D8EEE]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([Country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD FOREIGN KEY([ServiceType_id])
REFERENCES [dbo].[ServiceType] ([id])
GO
ALTER TABLE [dbo].[Travels]  WITH CHECK ADD  CONSTRAINT [FK__Travels__arrival__35BCFE0A] FOREIGN KEY([arrivalCity_id])
REFERENCES [dbo].[City] ([id])
GO
ALTER TABLE [dbo].[Travels] CHECK CONSTRAINT [FK__Travels__arrival__35BCFE0A]
GO
ALTER TABLE [dbo].[Travels]  WITH CHECK ADD FOREIGN KEY([briefcase_id])
REFERENCES [dbo].[Briefcase] ([id])
GO
ALTER TABLE [dbo].[Travels]  WITH CHECK ADD  CONSTRAINT [FK__Travels__originC__34C8D9D1] FOREIGN KEY([originCity_id])
REFERENCES [dbo].[City] ([id])
GO
ALTER TABLE [dbo].[Travels] CHECK CONSTRAINT [FK__Travels__originC__34C8D9D1]
GO
