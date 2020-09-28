CREATE TABLE Currency (
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [Name]   NVARCHAR(50),
  [Code]   VARCHAR(3),
  [Symbol] NVARCHAR(5)
  CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) ON [PRIMARY]

);
GO


INSERT INTO Currency (Name, Code, Symbol) VALUES ('Leke', 'ALL', 'Lek');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'USD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Afghanis', 'AFN', '؋');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'ARS', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Guilders', 'AWG', 'ƒ');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'AUD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('New Manats', 'AZN', 'ман');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'BSD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'BBD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rubles', 'BYR', 'p.');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Euro', 'EUR', '€');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'BZD', 'BZ$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'BMD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Bolivianos', 'BOB', '$b');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Convertible Marka', 'BAM', 'KM');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pula', 'BWP', 'P');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Leva', 'BGN', 'лв');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Reais', 'BRL', 'R$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'GBP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'BND', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Riels', 'KHR', '៛');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'CAD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'KYD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'CLP', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Yuan Renminbi', 'CNY', '¥');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'COP', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Colón', 'CRC', '₡');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Kuna', 'HRK', 'kn');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'CUP', '₱');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Koruny', 'CZK', 'Kč');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Kroner', 'DKK', 'kr');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'DOP ', 'RD$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'XCD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'EGP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Colones', 'SVC', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'FKP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'FJD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Cedis', 'GHC', '¢');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'GIP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Quetzales', 'GTQ', 'Q');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'GGP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'GYD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Lempiras', 'HNL', 'L');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'HKD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Forint', 'HUF', 'Ft');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Kronur', 'ISK', 'kr');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rupees', 'INR', 'Rp');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rupiahs', 'IDR', 'Rp');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rials', 'IRR', '﷼');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'IMP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('New Shekels', 'ILS', '₪');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'JMD', 'J$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Yen', 'JPY', '¥');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'JEP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Tenge', 'KZT', 'лв');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Won', 'KPW', '₩');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Won', 'KRW', '₩');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Soms', 'KGS', 'лв');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Kips', 'LAK', '₭');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Lati', 'LVL', 'Ls');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pounds', 'LBP', '£');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'LRD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Switzerland Francs', 'CHF', 'CHF');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Litai', 'LTL', 'Lt');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Denars', 'MKD', 'ден');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Ringgits', 'MYR', 'RM');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rupees', 'MUR', '₨');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Pesos', 'MXN', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Tugriks', 'MNT', '₮');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Meticais', 'MZN', 'MT');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'NAD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rupees', 'NPR', '₨');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Guilders', 'ANG', 'ƒ');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Dollars', 'NZD', '$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Cordobas', 'NIO', 'C$');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Nairas', 'NGN', '₦');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Krone', 'NOK', 'kr');
INSERT INTO Currency (Name, Code, Symbol) VALUES ('Rials', 'OMR', '﷼');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rupees', 'PKR', '₨');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Balboa', 'PAB', 'B/.');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Guarani', 'PYG', 'Gs');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Nuevos Soles', 'PEN', 'S/.');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Pesos', 'PHP', 'Php');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Zlotych', 'PLN', 'zł');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rials', 'QAR', '﷼');
INSERT INTO Currency (name, Code, Symbol) VALUES ('New Lei', 'RON', 'lei');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rubles', 'RUB', 'руб');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Pounds', 'SHP', '£');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Riyals', 'SAR', '﷼');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dinars', 'RSD', 'Дин.');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rupees', 'SCR', '₨');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dollars', 'SGD', '$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dollars', 'SBD', '$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Shillings', 'SOS', 'S');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rand', 'ZAR', 'R');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rupees', 'LKR', '₨');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Kronor', 'SEK', 'kr');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dollars', 'SRD', '$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Pounds', 'SYP', '£');
INSERT INTO Currency (name, Code, Symbol) VALUES ('New Dollars', 'TWD', 'NT$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Baht', 'THB', '฿');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dollars', 'TTD', 'TT$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Lira', 'TRY', '₺');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Liras', 'TRL', '£');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dollars', 'TVD', '$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Hryvnia', 'UAH', '₴');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Pesos', 'UYU', '$U');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Sums', 'UZS', 'лв');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Bolivares Fuertes', 'VEF', 'Bs');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Dong', 'VND', '₫');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rials', 'YER', '﷼');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Zimbabwe Dollars', 'ZWD', 'Z$');
INSERT INTO Currency (name, Code, Symbol) VALUES ('Rupees', 'INR', '₹');

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