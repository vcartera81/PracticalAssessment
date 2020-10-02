CREATE DATABASE [Spendings]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Spendings', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Spendings.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Spendings_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Spendings_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Spendings] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Spendings] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Spendings] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Spendings] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Spendings] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Spendings] SET ARITHABORT OFF 
GO
ALTER DATABASE [Spendings] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Spendings] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Spendings] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Spendings] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Spendings] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Spendings] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Spendings] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Spendings] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Spendings] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Spendings] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Spendings] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Spendings] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Spendings] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Spendings] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Spendings] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Spendings] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Spendings] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Spendings] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Spendings] SET  MULTI_USER 
GO
ALTER DATABASE [Spendings] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Spendings] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Spendings] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Spendings] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Spendings] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Spendings] SET QUERY_STORE = OFF
GO
USE [Spendings]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02-Oct-20 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 02-Oct-20 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [varchar](3) NULL,
	[Symbol] [nvarchar](5) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipient]    Script Date: 02-Oct-20 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Recipient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 02-Oct-20 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OccuredOn] [datetime2](7) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Amount] [float] NOT NULL,
	[RecipientId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions]    Script Date: 02-Oct-20 08:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_Transactions] ON [dbo].[Transaction]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transactions_Currency]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Recipient] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[Recipient] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transactions_Recipient]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transactions_Category]
GO
USE [master]
GO
ALTER DATABASE [Spendings] SET  READ_WRITE 
GO

USE [Spendings]
GO

INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Leke', 'ALL', 'Lek');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'USD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Afghanis', 'AFN', '؋');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'ARS', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Guilders', 'AWG', 'ƒ');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'AUD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('New Manats', 'AZN', 'ман');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'BSD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'BBD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rubles', 'BYR', 'p.');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Euro', 'EUR', '€');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'BZD', 'BZ$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'BMD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Bolivianos', 'BOB', '$b');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Convertible Marka', 'BAM', 'KM');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pula', 'BWP', 'P');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Leva', 'BGN', 'лв');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Reais', 'BRL', 'R$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'GBP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'BND', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Riels', 'KHR', '៛');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'CAD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'KYD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'CLP', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Yuan Renminbi', 'CNY', '¥');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'COP', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Colón', 'CRC', '₡');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Kuna', 'HRK', 'kn');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'CUP', '₱');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Koruny', 'CZK', 'Kč');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Kroner', 'DKK', 'kr');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'DOP ', 'RD$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'XCD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'EGP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Colones', 'SVC', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'FKP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'FJD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Cedis', 'GHC', '¢');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'GIP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Quetzales', 'GTQ', 'Q');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'GGP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'GYD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Lempiras', 'HNL', 'L');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'HKD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Forint', 'HUF', 'Ft');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Kronur', 'ISK', 'kr');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rupees', 'INR', 'Rp');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rupiahs', 'IDR', 'Rp');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rials', 'IRR', '﷼');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'IMP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('New Shekels', 'ILS', '₪');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'JMD', 'J$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Yen', 'JPY', '¥');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'JEP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Tenge', 'KZT', 'лв');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Won', 'KPW', '₩');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Won', 'KRW', '₩');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Soms', 'KGS', 'лв');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Kips', 'LAK', '₭');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Lati', 'LVL', 'Ls');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pounds', 'LBP', '£');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'LRD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Switzerland Francs', 'CHF', 'CHF');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Litai', 'LTL', 'Lt');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Denars', 'MKD', 'ден');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Ringgits', 'MYR', 'RM');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rupees', 'MUR', '₨');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Pesos', 'MXN', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Tugriks', 'MNT', '₮');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Meticais', 'MZN', 'MT');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'NAD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rupees', 'NPR', '₨');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Guilders', 'ANG', 'ƒ');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Dollars', 'NZD', '$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Cordobas', 'NIO', 'C$');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Nairas', 'NGN', '₦');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Krone', 'NOK', 'kr');
INSERT INTO [Currency] (Name, Code, Symbol) VALUES ('Rials', 'OMR', '﷼');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rupees', 'PKR', '₨');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Balboa', 'PAB', 'B/.');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Guarani', 'PYG', 'Gs');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Nuevos Soles', 'PEN', 'S/.');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Pesos', 'PHP', 'Php');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Zlotych', 'PLN', 'zł');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rials', 'QAR', '﷼');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('New Lei', 'RON', 'lei');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rubles', 'RUB', 'руб');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Pounds', 'SHP', '£');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Riyals', 'SAR', '﷼');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dinars', 'RSD', 'Дин.');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rupees', 'SCR', '₨');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dollars', 'SGD', '$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dollars', 'SBD', '$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Shillings', 'SOS', 'S');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rand', 'ZAR', 'R');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rupees', 'LKR', '₨');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Kronor', 'SEK', 'kr');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dollars', 'SRD', '$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Pounds', 'SYP', '£');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('New Dollars', 'TWD', 'NT$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Baht', 'THB', '฿');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dollars', 'TTD', 'TT$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Lira', 'TRY', '₺');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Liras', 'TRL', '£');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dollars', 'TVD', '$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Hryvnia', 'UAH', '₴');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Pesos', 'UYU', '$U');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Sums', 'UZS', 'лв');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Bolivares Fuertes', 'VEF', 'Bs');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Dong', 'VND', '₫');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rials', 'YER', '﷼');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Zimbabwe Dollars', 'ZWD', 'Z$');
INSERT INTO [Currency] (name, Code, Symbol) VALUES ('Rupees', 'INR', '₹');

INSERT INTO [Category] SELECT 1, 'Salary'
INSERT INTO [Category] SELECT 0, 'Groceries'
INSERT INTO [Category] SELECT 0, 'Clothing'
INSERT INTO [Category] SELECT 0, 'Entertainment'
INSERT INTO [Category] SELECT 0, 'Services'
INSERT INTO [Category] SELECT 0, 'Food and Drinks'
INSERT INTO [Category] SELECT 0, 'Transportation'

INSERT INTO [Recipient] SELECT 'John Doe'
INSERT INTO [Recipient] SELECT 'Adam Sandler'
INSERT INTO [Recipient] SELECT 'Mr Anderson'

INSERT INTO [Transaction] SELECT
'2020-02-12 16:35:11',
'Boots',
115.90,
(SELECT TOP 1 [Id] FROM [Recipient] WHERE [Name] = 'John Doe'), 
(SELECT TOP 1 [Id] FROM [Currency] WHERE [Code] = 'AUD'),
(SELECT TOP 1 [Id] FROM [Category] WHERE [Name] = 'Clothing')

INSERT INTO [Transaction] SELECT
'2020-03-21 11:20:01',
'Lunch',
16.30,
(SELECT TOP 1 [Id] FROM [Recipient] WHERE [Name] = 'Adam Sandler'), 
(SELECT TOP 1 [Id] FROM [Currency] WHERE [Code] = 'CHF'),
(SELECT TOP 1 [Id] FROM [Category] WHERE [Name] = 'Food and Drinks')

INSERT INTO [Transaction] SELECT
'2020-03-24 09:20:25',
'Tram tickets',
4.70,
(SELECT TOP 1 [Id] FROM [Recipient] WHERE [Name] = 'Mr Anderson'), 
(SELECT TOP 1 [Id] FROM [Currency] WHERE [Code] = 'CHF'),
(SELECT TOP 1 [Id] FROM [Category] WHERE [Name] = 'Transportation')

INSERT INTO [Transaction] SELECT
'2020-04-01 18:55:15',
'Jazz cafe',
170,
(SELECT TOP 1 [Id] FROM [Recipient] WHERE [Name] = 'John Doe'), 
(SELECT TOP 1 [Id] FROM [Currency] WHERE [Code] = 'USD'),
(SELECT TOP 1 [Id] FROM [Category] WHERE [Name] = 'Entertainment')

INSERT INTO [Transaction] SELECT
'2020-04-12 16:15:41',
'Gym',
25,
(SELECT TOP 1 [Id] FROM [Recipient] WHERE [Name] = 'Adam Sandler'), 
(SELECT TOP 1 [Id] FROM [Currency] WHERE [Code] = 'AUD'),
(SELECT TOP 1 [Id] FROM [Category] WHERE [Name] = 'Services')