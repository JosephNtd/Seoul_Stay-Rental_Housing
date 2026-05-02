
USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Seoul_Stay_2')
    DROP DATABASE Seoul_Stay_2
GO
CREATE DATABASE Seoul_Stay_2
GO

USE Seoul_Stay_2
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[UserTypes](
    [ID]   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name] [nvarchar](50)    NOT NULL,
    CONSTRAINT [PK_UserTypes]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_UserTypes_GUID]  UNIQUE ([GUID])
)
GO

CREATE TABLE [dbo].[ItemTypes](
    [ID]   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name] [nvarchar](50)    NOT NULL,
    CONSTRAINT [PK_ItemTypes]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemTypes_GUID]  UNIQUE ([GUID])
)
GO

CREATE TABLE [dbo].[TransactionTypes](
    [ID]   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name] [nvarchar](50)    NOT NULL,
    CONSTRAINT [PK_TransactionTypes]      PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_TransactionTypes_GUID] UNIQUE ([GUID])
)
GO

CREATE TABLE [dbo].[Areas](
    [ID]   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name] [nvarchar](100)   NOT NULL,
    CONSTRAINT [PK_Areas]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Areas_GUID]  UNIQUE ([GUID])
)
GO

-- Dimdate

CREATE TABLE [dbo].[DimDates](
    [ID]         [bigint]     NOT NULL,
    [Date]       [date]       NOT NULL,
    [Year]       [int]        NOT NULL,
    [Quarter]    [int]        NOT NULL,
    [Month]      [int]        NOT NULL,
    [MonthName]  [varchar](10) NOT NULL,
    [DayOfMonth] [int]        NOT NULL,
    [DayOfWeek]  [int]        NOT NULL,
    [DayName]    [varchar](10) NOT NULL,
    [IsHoliday]  [bit]        NOT NULL DEFAULT 0,
    CONSTRAINT [PK_DimDates]      PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_DimDates_Date] UNIQUE ([Date])
)
GO

-- AMENITIES & ATTRACTIONS

CREATE TABLE [dbo].[Amenities](
    [ID]       [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]     [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name]     [nvarchar](100)   NOT NULL,
    [IconName] [nvarchar](100)   NULL,
    CONSTRAINT [PK_Amenities]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Amenities_GUID]  UNIQUE ([GUID])
)
GO

CREATE TABLE [dbo].[Attractions](
    [ID]      [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]    [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [AreaID]  [bigint]          NOT NULL,
    [Name]    [nvarchar](150)   NOT NULL,
    [Address] [nvarchar](500)   NOT NULL,
    CONSTRAINT [PK_Attractions]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Attractions_GUID]  UNIQUE ([GUID])
)
GO

-- CANCELLATION

CREATE TABLE [dbo].[CancellationPolicies](
    [ID]                     [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                   [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [Name]                   [nvarchar](100)   NOT NULL,
    [PlatformCommissionRate] [decimal](5,2)    NOT NULL,      
    CONSTRAINT [PK_CancellationPolicies]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_CancellationPolicies_GUID]  UNIQUE ([GUID]),
    CONSTRAINT [CK_CancellationPolicies_Rate]  CHECK ([PlatformCommissionRate] BETWEEN 0 AND 100)
)
GO

CREATE TABLE [dbo].[CancellationRefundFees](
    [ID]                   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                 [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [CancellationPolicyID] [bigint]          NOT NULL,
    [DaysLeft]             [int]             NOT NULL,
    [PenaltyPercentage]    [decimal](5,2)    NOT NULL,
    CONSTRAINT [PK_CancellationRefundFees]            PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_CancellationRefundFees_GUID]       UNIQUE ([GUID]),
    CONSTRAINT [CK_CancellationRefundFees_DaysLeft]   CHECK ([DaysLeft] >= 0),
    CONSTRAINT [CK_CancellationRefundFees_Penalty]    CHECK ([PenaltyPercentage] BETWEEN 0 AND 100)
)
GO

-- SECTION 5 — COUPONS

CREATE TABLE [dbo].[Coupons](
    [ID]                    [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                  [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [CouponCode]            [nvarchar](50)    NOT NULL,
    [DiscountPercent]       [decimal](4,1)    NOT NULL,
    [MaximumDiscountAmount] [decimal](10,2)   NOT NULL,        
    [StartDate]             [date]            NOT NULL DEFAULT CAST(GETDATE() AS date), 
    [ExpirationDate]        [date]            NULL,             -- (NULL = no expiry)
    [MaxUsageCount]         [int]             NULL,             -- (NULL = unlimited)
    [CurrentUsageCount]     [int]             NOT NULL DEFAULT 0,                      
    [IsActive]              [bit]             NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Coupons]              PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Coupons_GUID]         UNIQUE ([GUID]),
    CONSTRAINT [UQ_Coupons_CouponCode]   UNIQUE ([CouponCode]),
    CONSTRAINT [CK_Coupons_Discount]     CHECK ([DiscountPercent] BETWEEN 0 AND 100),
    CONSTRAINT [CK_Coupons_Usage]        CHECK ([CurrentUsageCount] >= 0),
    CONSTRAINT [CK_Coupons_DateRange]    CHECK ([ExpirationDate] IS NULL OR [ExpirationDate] > [StartDate])
)
GO

-- USERS
-- Gender: 0=Unknown  1=Male  2=Female  3=Other
-- UserTypes: 1=admin  2=host  3=guest

CREATE TABLE [dbo].[Users](
    [ID]             [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]           [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [UserTypeID]     [bigint]          NOT NULL,
    [Username]       [varchar](50)     NOT NULL,
    [Password]       [varchar](255)    NOT NULL,               --  hash sau
    [FullName]       [nvarchar](100)   NOT NULL,
    [Email]          [varchar](100)    NULL,
    [PhoneNumber]    [varchar](20)     NULL,
    [Gender]         [tinyint]         NOT NULL DEFAULT 0,
    [BirthDate]      [date]            NULL,
    [Country]        [nvarchar](50)    NULL,
    [ProfilePicture] [varchar](500)    NULL,
    [FamilyCount]    [int]             NOT NULL DEFAULT 1,
    [CreatedDate]    [datetime]        NOT NULL DEFAULT GETDATE(),
    [IsActive]       [bit]             NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Users]             PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Users_GUID]        UNIQUE ([GUID]),
    CONSTRAINT [UQ_Users_Username]    UNIQUE ([Username]),
    CONSTRAINT [UQ_Users_Email]       UNIQUE ([Email]),
    CONSTRAINT [CK_Users_Gender]      CHECK ([Gender] IN (0, 1, 2, 3)),
    CONSTRAINT [CK_Users_FamilyCount] CHECK ([FamilyCount] >= 1)
)
GO

-- ITEMS

CREATE TABLE [dbo].[Items](
    [ID]                   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                 [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [UserID]               [bigint]          NOT NULL,
    [ItemTypeID]           [bigint]          NOT NULL,
    [AreaID]               [bigint]          NOT NULL,
    [Title]                [nvarchar](100)   NOT NULL,     
    [Capacity]             [int]             NOT NULL,
    [NumberOfBeds]         [int]             NOT NULL,
    [NumberOfBedrooms]     [int]             NOT NULL,
    [NumberOfBathrooms]    [int]             NOT NULL,
    [ExactAddress]         [nvarchar](500)   NOT NULL,        
    [ApproximateAddress]   [nvarchar](250)   NOT NULL,     
    [Description]          [nvarchar](2000)  NOT NULL,
    [HostRules]            [nvarchar](2000)  NOT NULL,
    [MinimumNights]        [int]             NOT NULL DEFAULT 1,
    [MaximumNights]        [int]             NOT NULL DEFAULT 365,
    [CreatedDate]          [datetime]        NOT NULL DEFAULT GETDATE(),
    [IsActive]             [bit]             NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Items]             PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Items_GUID]        UNIQUE ([GUID]),
    CONSTRAINT [CK_Items_Capacity]    CHECK ([Capacity] >= 1),
    CONSTRAINT [CK_Items_Nights]      CHECK ([MaximumNights] >= [MinimumNights] AND [MinimumNights] >= 1)
)
GO

CREATE TABLE [dbo].[ItemAmenities](
    [ID]        [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]      [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [ItemID]    [bigint]          NOT NULL,
    [AmenityID] [bigint]          NOT NULL,
    CONSTRAINT [PK_ItemAmenities]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemAmenities_GUID]  UNIQUE ([GUID]),
    CONSTRAINT [UQ_ItemAmenities_Pair]  UNIQUE ([ItemID], [AmenityID])   -- Không cho trùng cặp
)
GO

CREATE TABLE [dbo].[ItemAttractions](
    [ID]            [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]          [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [ItemID]        [bigint]          NOT NULL,
    [AttractionID]  [bigint]          NOT NULL,
    [Distance]      [decimal](5,1)    NULL,
    [DurationOnFoot][int]             NULL,    
    [DurationByCar] [int]             NULL,          
    CONSTRAINT [PK_ItemAttractions]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemAttractions_GUID]  UNIQUE ([GUID]),
    CONSTRAINT [UQ_ItemAttractions_Pair]  UNIQUE ([ItemID], [AttractionID])
)
GO

CREATE TABLE [dbo].[ItemPictures](
    [ID]              [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]            [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [ItemID]          [bigint]          NOT NULL,
    [PictureFileName] [nvarchar](500)   NOT NULL,
    [DisplayOrder]    [int]             NOT NULL DEFAULT 0,
    CONSTRAINT [PK_ItemPictures]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemPictures_GUID]  UNIQUE ([GUID])
)
GO

CREATE TABLE [dbo].[ItemPrices](
    [ID]                   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                 [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [ItemID]               [bigint]          NOT NULL,
    [Date]                 [date]            NOT NULL,
    [Price]                [decimal](10,2)   NOT NULL,
    [CancellationPolicyID] [bigint]          NOT NULL,
    CONSTRAINT [PK_ItemPrices]           PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemPrices_GUID]      UNIQUE ([GUID]),
    CONSTRAINT [UQ_ItemPrices_ItemDate]  UNIQUE ([ItemID], [Date]),      -- Mỗi item chỉ 1 giá/ngày
    CONSTRAINT [CK_ItemPrices_Price]     CHECK ([Price] > 0)
)
GO

-- THÊM MỚI: Quản lý tình trạng phòng trống (tách biệt với giá)
CREATE TABLE [dbo].[ItemAvailability](
    [ID]          [bigint] IDENTITY(1,1)  NOT NULL,
    [ItemID]      [bigint] NOT NULL,
    [Date]        [date]   NOT NULL,
    [IsAvailable] [bit]    NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ItemAvailability]          PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_ItemAvailability_ItemDate] UNIQUE ([ItemID], [Date])
)
GO


-- SECTION 8 — TRANSACTIONS


CREATE TABLE [dbo].[Transactions](
    [ID]                [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]              [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [UserID]            [bigint]          NOT NULL,
    [TransactionTypeID] [bigint]          NOT NULL,
    [Amount]            [decimal](18,2)   NOT NULL,
    [TransactionDate]   [date]            NOT NULL,
    [GatewayReturnID]   [nvarchar](100)   NOT NULL,
    CONSTRAINT [PK_Transactions]          PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Transactions_GUID]     UNIQUE ([GUID]),
    CONSTRAINT [CK_Transactions_Amount]   CHECK ([Amount] > 0)
)
GO


-- SECTION 9 — BOOKINGS

-- BookingStatus: Pending → Confirmed → CheckedIn → Completed
--                                    ↘ Cancelled → Refunded

CREATE TABLE [dbo].[Bookings](
    [ID]                   [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]                 [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [UserID]               [bigint]          NOT NULL,      
    [ItemID]               [bigint]          NOT NULL,
    [CheckInDate]          [date]            NOT NULL,
    [CheckOutDate]         [date]            NOT NULL,
    [NumberOfGuests]       [int]             NOT NULL,
    [PricePerNight]        [decimal](10,2)   NOT NULL,
    [TotalPrice]           [decimal](10,2)   NOT NULL,        -- Snapshot: PricePerNight × nights
    [DiscountAmount]       [decimal](10,2)   NOT NULL DEFAULT 0,
    [FinalPrice]           [decimal](10,2)   NOT NULL,
    [CancellationPolicyID] [bigint]          NOT NULL,
    [BookingStatus]        [varchar](20)     NOT NULL DEFAULT 'Pending',
    [BookingDate]          [datetime]        NOT NULL DEFAULT GETDATE(),
    [SpecialRequests]      [nvarchar](1000)  NULL,
    [TransactionID]        [bigint]          NULL,
    CONSTRAINT [PK_Bookings]             PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Bookings_GUID]        UNIQUE ([GUID]),
    CONSTRAINT [CK_Bookings_Dates]       CHECK ([CheckOutDate] > [CheckInDate]),
    CONSTRAINT [CK_Bookings_Guests]      CHECK ([NumberOfGuests] >= 1),
    CONSTRAINT [CK_Bookings_Discount]    CHECK ([DiscountAmount] >= 0),
    CONSTRAINT [CK_Bookings_FinalPrice]  CHECK ([FinalPrice] >= 0),
    CONSTRAINT [CK_Bookings_Status]      CHECK ([BookingStatus] IN (   
        'Pending', 'Confirmed', 'CheckedIn', 'Completed', 'Cancelled', 'Refunded'
    ))
)
GO

CREATE TABLE [dbo].[BookingCoupons](
    [ID]             [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]           [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [BookingID]      [bigint]          NOT NULL,
    [CouponID]       [bigint]          NOT NULL,
    [DiscountApplied][decimal](10,2)   NOT NULL,
    [AppliedDate]    [datetime]        NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_BookingCoupons]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_BookingCoupons_GUID]  UNIQUE ([GUID]),
    CONSTRAINT [UQ_BookingCoupons_Pair]  UNIQUE ([BookingID], [CouponID])
)
GO

CREATE TABLE [dbo].[BookingStatusHistory](
    [ID]              [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]            [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [BookingID]       [bigint]          NOT NULL,
    [OldStatus]       [varchar](20)     NULL,
    [NewStatus]       [varchar](20)     NOT NULL,
    [ChangedDate]     [datetime]        NOT NULL DEFAULT GETDATE(),
    [ChangedByUserID] [bigint]          NULL,                 
    [Notes]           [nvarchar](500)   NULL,
    CONSTRAINT [PK_BookingStatusHistory]         PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_BookingStatusHistory_GUID]    UNIQUE ([GUID]),
    CONSTRAINT [CK_BSH_OldStatus]  CHECK ([OldStatus] IS NULL OR [OldStatus] IN (
        'Pending', 'Confirmed', 'CheckedIn', 'Completed', 'Cancelled', 'Refunded'
    )),
    CONSTRAINT [CK_BSH_NewStatus]  CHECK ([NewStatus] IN (
        'Pending', 'Confirmed', 'CheckedIn', 'Completed', 'Cancelled', 'Refunded'
    ))
)
GO


-- SECTION 10 — REVIEWS  (THÊM MỚI)


CREATE TABLE [dbo].[Reviews](
    [ID]          [bigint]          IDENTITY(1,1)  NOT NULL,
    [GUID]        [uniqueidentifier] NOT NULL DEFAULT NEWID(),
    [BookingID]   [bigint]          NOT NULL,
    [ReviewerID]  [bigint]          NOT NULL,         -- FK → Users (người viết)
    [RevieweeID]  [bigint]          NULL,             -- FK → Users (người được đánh giá, NULL nếu review chỗ ở)
    [ItemID]      [bigint]          NULL,             -- NULL = review người dùng, NOT NULL = review chỗ ở
    [Rating]      [tinyint]         NOT NULL,
    [Comment]     [nvarchar](2000)  NULL,
    [CreatedDate] [datetime]        NOT NULL DEFAULT GETDATE(),
    [IsActive]    [bit]             NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Reviews]             PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_Reviews_GUID]        UNIQUE ([GUID]),
    CONSTRAINT [CK_Reviews_Rating]      CHECK ([Rating] BETWEEN 1 AND 5),
    CONSTRAINT [CK_Reviews_NotSelf]     CHECK ([ReviewerID] <> [RevieweeID] OR [RevieweeID] IS NULL),
    CONSTRAINT [CK_Reviews_Target]      CHECK (
        ([RevieweeID] IS NOT NULL AND [ItemID] IS NULL) OR   -- review người
        ([RevieweeID] IS NULL     AND [ItemID] IS NOT NULL)  -- review chỗ ở
    )
)
GO

-- SECTION 11 — FOREIGN KEY CONSTRAINTS

-- Areas → Attractions
ALTER TABLE [dbo].[Attractions]
    ADD CONSTRAINT [FK_Attractions_Areas]
    FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas]([ID])
GO

-- CancellationPolicies → CancellationRefundFees
ALTER TABLE [dbo].[CancellationRefundFees]
    ADD CONSTRAINT [FK_CancellationRefundFees_CancellationPolicies]
    FOREIGN KEY ([CancellationPolicyID]) REFERENCES [dbo].[CancellationPolicies]([ID])
    ON DELETE CASCADE ON UPDATE CASCADE
GO

-- UserTypes → Users
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [FK_Users_UserTypes]
    FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserTypes]([ID])
GO

-- Users, Areas, ItemTypes → Items
ALTER TABLE [dbo].[Items]
    ADD CONSTRAINT [FK_Items_Users]
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([ID])
GO
ALTER TABLE [dbo].[Items]
    ADD CONSTRAINT [FK_Items_Areas]
    FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Areas]([ID])
GO
ALTER TABLE [dbo].[Items]
    ADD CONSTRAINT [FK_Items_ItemTypes]
    FOREIGN KEY ([ItemTypeID]) REFERENCES [dbo].[ItemTypes]([ID])
GO

-- Items, Amenities → ItemAmenities
ALTER TABLE [dbo].[ItemAmenities]
    ADD CONSTRAINT [FK_ItemAmenities_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemAmenities]
    ADD CONSTRAINT [FK_ItemAmenities_Amenities]
    FOREIGN KEY ([AmenityID]) REFERENCES [dbo].[Amenities]([ID])
GO

-- Items, Attractions → ItemAttractions
ALTER TABLE [dbo].[ItemAttractions]
    ADD CONSTRAINT [FK_ItemAttractions_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemAttractions]
    ADD CONSTRAINT [FK_ItemAttractions_Attractions]
    FOREIGN KEY ([AttractionID]) REFERENCES [dbo].[Attractions]([ID])
GO

-- Items → ItemPictures
ALTER TABLE [dbo].[ItemPictures]
    ADD CONSTRAINT [FK_ItemPictures_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID]) ON DELETE CASCADE
GO

-- Items, CancellationPolicies, DimDates → ItemPrices
ALTER TABLE [dbo].[ItemPrices]
    ADD CONSTRAINT [FK_ItemPrices_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemPrices]
    ADD CONSTRAINT [FK_ItemPrices_CancellationPolicies]
    FOREIGN KEY ([CancellationPolicyID]) REFERENCES [dbo].[CancellationPolicies]([ID])
GO
ALTER TABLE [dbo].[ItemPrices]
    ADD CONSTRAINT [FK_ItemPrices_DimDates]
    FOREIGN KEY ([Date]) REFERENCES [dbo].[DimDates]([Date])
GO

-- Items, DimDates → ItemAvailability
ALTER TABLE [dbo].[ItemAvailability]
    ADD CONSTRAINT [FK_ItemAvailability_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemAvailability]
    ADD CONSTRAINT [FK_ItemAvailability_DimDates]
    FOREIGN KEY ([Date]) REFERENCES [dbo].[DimDates]([Date])
GO

-- Users, TransactionTypes, DimDates → Transactions
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transactions_Users]
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([ID])
GO
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transactions_TransactionTypes]
    FOREIGN KEY ([TransactionTypeID]) REFERENCES [dbo].[TransactionTypes]([ID])
GO
ALTER TABLE [dbo].[Transactions]
    ADD CONSTRAINT [FK_Transactions_DimDates]
    FOREIGN KEY ([TransactionDate]) REFERENCES [dbo].[DimDates]([Date])
GO

-- Users, Items, CancellationPolicies, Transactions, DimDates → Bookings
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_Users]
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([ID])
GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID])
GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_CancellationPolicies]
    FOREIGN KEY ([CancellationPolicyID]) REFERENCES [dbo].[CancellationPolicies]([ID])
GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_Transactions]
    FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions]([ID])
GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_CheckInDate_DimDates]
    FOREIGN KEY ([CheckInDate]) REFERENCES [dbo].[DimDates]([Date])
GO
ALTER TABLE [dbo].[Bookings]
    ADD CONSTRAINT [FK_Bookings_CheckOutDate_DimDates]
    FOREIGN KEY ([CheckOutDate]) REFERENCES [dbo].[DimDates]([Date])
GO

-- Bookings, Coupons → BookingCoupons
ALTER TABLE [dbo].[BookingCoupons]
    ADD CONSTRAINT [FK_BookingCoupons_Bookings]
    FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings]([ID])
GO
ALTER TABLE [dbo].[BookingCoupons]
    ADD CONSTRAINT [FK_BookingCoupons_Coupons]
    FOREIGN KEY ([CouponID]) REFERENCES [dbo].[Coupons]([ID])
GO

-- Bookings, Users → BookingStatusHistory
ALTER TABLE [dbo].[BookingStatusHistory]
    ADD CONSTRAINT [FK_BookingStatusHistory_Bookings]
    FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings]([ID])
GO
ALTER TABLE [dbo].[BookingStatusHistory]
    ADD CONSTRAINT [FK_BookingStatusHistory_ChangedByUser]
    FOREIGN KEY ([ChangedByUserID]) REFERENCES [dbo].[Users]([ID])
GO

-- Bookings, Users, Items → Reviews
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Bookings]
    FOREIGN KEY ([BookingID]) REFERENCES [dbo].[Bookings]([ID])
GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Reviewer]
    FOREIGN KEY ([ReviewerID]) REFERENCES [dbo].[Users]([ID])
GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Reviewee]
    FOREIGN KEY ([RevieweeID]) REFERENCES [dbo].[Users]([ID])
GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items]([ID])
GO

-- SECTION 12 — INDEXES (Non-clustered trên cột truy vấn thường)

CREATE NONCLUSTERED INDEX [IX_Users_UserTypeID]
    ON [dbo].[Users]([UserTypeID])
GO
CREATE NONCLUSTERED INDEX [IX_Users_IsActive]
    ON [dbo].[Users]([IsActive]) INCLUDE ([UserTypeID], [Username])
GO
CREATE NONCLUSTERED INDEX [IX_Items_UserID]
    ON [dbo].[Items]([UserID])
GO
CREATE NONCLUSTERED INDEX [IX_Items_AreaID]
    ON [dbo].[Items]([AreaID])
GO
CREATE NONCLUSTERED INDEX [IX_Items_IsActive_AreaID]
    ON [dbo].[Items]([IsActive], [AreaID]) INCLUDE ([UserID], [ItemTypeID], [Capacity])
GO
CREATE NONCLUSTERED INDEX [IX_ItemPrices_ItemID_Date]
    ON [dbo].[ItemPrices]([ItemID], [Date]) INCLUDE ([Price], [CancellationPolicyID])
GO
CREATE NONCLUSTERED INDEX [IX_ItemAvailability_ItemID_Date]
    ON [dbo].[ItemAvailability]([ItemID], [Date]) INCLUDE ([IsAvailable])
GO
CREATE NONCLUSTERED INDEX [IX_Bookings_UserID]
    ON [dbo].[Bookings]([UserID])
GO
CREATE NONCLUSTERED INDEX [IX_Bookings_ItemID]
    ON [dbo].[Bookings]([ItemID])
GO
CREATE NONCLUSTERED INDEX [IX_Bookings_CheckInDate]
    ON [dbo].[Bookings]([CheckInDate]) INCLUDE ([CheckOutDate], [ItemID], [UserID])
GO
CREATE NONCLUSTERED INDEX [IX_Bookings_Status]
    ON [dbo].[Bookings]([BookingStatus]) INCLUDE ([UserID], [ItemID], [FinalPrice])
GO
CREATE NONCLUSTERED INDEX [IX_Transactions_UserID]
    ON [dbo].[Transactions]([UserID])
GO
CREATE NONCLUSTERED INDEX [IX_Transactions_Date]
    ON [dbo].[Transactions]([TransactionDate]) INCLUDE ([UserID], [Amount])
GO
CREATE NONCLUSTERED INDEX [IX_Reviews_ItemID]
    ON [dbo].[Reviews]([ItemID]) INCLUDE ([Rating], [CreatedDate])
GO
CREATE NONCLUSTERED INDEX [IX_Reviews_RevieweeID]
    ON [dbo].[Reviews]([RevieweeID]) INCLUDE ([Rating])
GO

-- DATA
-- ---- DimDates: tự sinh 2022-01-01 đến 2027-12-31 -----------
DECLARE @d DATE = '2022-01-01'
DECLARE @end DATE = '2027-12-31'
WHILE @d <= @end
BEGIN
    INSERT INTO [dbo].[DimDates]
        ([ID],[Date],[Year],[Quarter],[Month],[MonthName],[DayOfMonth],[DayOfWeek],[DayName],[IsHoliday])
    VALUES (
        CAST(FORMAT(@d,'yyyyMMdd') AS bigint),
        @d,
        YEAR(@d),
        DATEPART(QUARTER,@d),
        MONTH(@d),
        DATENAME(MONTH,@d),
        DAY(@d),
        DATEPART(WEEKDAY,@d),
        DATENAME(WEEKDAY,@d),
        0
    )
    SET @d = DATEADD(DAY,1,@d)
END
GO

-- ---- UserTypes ------------------------------------------
SET IDENTITY_INSERT [dbo].[UserTypes] ON
INSERT [dbo].[UserTypes] ([ID],[GUID],[Name]) VALUES
(1, N'fa3aa07f-020b-43c1-a733-6a564e1e1683', N'admin'),
(2, N'be7a2e2a-2d65-46bc-88b4-e79ef66be3a1', N'host'),
(3, N'c1d2e3f4-0000-0000-0000-000000000003', N'guest')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
GO

-- ---- ItemTypes ------------------------------------------
SET IDENTITY_INSERT [dbo].[ItemTypes] ON
INSERT [dbo].[ItemTypes] ([ID],[GUID],[Name]) VALUES
(1, N'60b72778-02fd-4602-a7a7-84f9ae17a6c2', N'Apartment'),
(2, N'dffe3bca-92b1-4760-8371-1cf145fd772c', N'House'),
(3, N'e62aa132-bcc2-40df-872f-e553ba156acb', N'Secondary unit'),
(4, N'5dc77099-57fe-4000-b321-63ba98194d66', N'Unique space'),
(5, N'727443d0-d486-4d3b-a3bb-2af3abe39dd7', N'Boutique hotel')
SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
GO

-- ---- TransactionTypes -----------------------------------
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON
INSERT [dbo].[TransactionTypes] ([ID],[GUID],[Name]) VALUES
(1, N'aa000001-0000-0000-0000-000000000001', N'Payment'),
(2, N'aa000002-0000-0000-0000-000000000002', N'Refund'),
(3, N'aa000003-0000-0000-0000-000000000003', N'Payout')
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
GO

-- ---- Areas (25 quận/huyện Seoul) ------------------------
SET IDENTITY_INSERT [dbo].[Areas] ON
INSERT [dbo].[Areas] ([ID],[GUID],[Name]) VALUES
(1,  N'2c64db74-3d74-46f6-bf61-2e6869e49a59', N'Dobong-gu'),
(2,  N'4f7bbac7-6d44-4662-bcd5-174bec2e0d59', N'Dongdaemun-gu'),
(3,  N'e65838a5-3e1c-4631-8909-d76601d9d859', N'Eunpyeong-gu'),
(4,  N'417668a8-6796-41cb-bc7a-687c66cd06eb', N'Gangbuk-gu'),
(5,  N'4306fc47-6862-4979-900d-9f3fd3d727c9', N'Gangdong-gu'),
(6,  N'6073b706-c1f4-4dde-94d4-4cfd7e9033ff', N'Gangnam-gu'),
(7,  N'f34a7e3c-be5b-4eaf-8b60-a01c02cbcf42', N'Gangseo-gu'),
(8,  N'c75476cc-36f0-4047-9f76-3c679d9f7720', N'Geumcheon-gu'),
(9,  N'40ba3129-4fbf-4ac4-88f7-5a7f7b7682fe', N'Guro-gu'),
(10, N'21117c16-473f-44a8-927b-afa8f5e5a578', N'Jongno-gu'),
(11, N'0191510c-86d9-4b7c-8c37-53897b89a51c', N'Jung-gu'),
(12, N'c826d5c8-353a-43e7-a8db-e596785a5709', N'Jungnang-gu'),
(13, N'e127ad40-e033-48bc-a37c-4fb7d49fdd65', N'Mapo-gu'),
(14, N'63a610a1-5de4-4c09-b113-39766145bb17', N'Nowon-gu'),
(15, N'3723c5bc-0643-4526-8f14-d21fb36275cc', N'Seocho-gu'),
(16, N'89f6e1fd-7e66-4716-a6a9-e6535cd77129', N'Seodaemun-gu'),
(17, N'0cebd35e-77d5-4d3f-bf2d-61e82fa4688b', N'Seongbuk-gu'),
(18, N'5a1a36c0-5111-4701-a4cc-5f3d4dff2f71', N'Seongdong-gu'),
(19, N'df0af61b-7e9e-4bd5-84dc-6d5f448bbd52', N'Songpa-gu'),
(20, N'f91550e6-21a0-4841-a0e7-98cd24945263', N'Yangcheon-gu'),
(21, N'37211b04-ea72-45f0-9cc8-e5ba28f51943', N'Yeongdeungpo-gu'),
(22, N'4a12b92d-5965-4784-a5ce-87ce3e0ada03', N'Yongsan-gu'),
(23, N'bb000023-0000-0000-0000-000000000023', N'Gwanak-gu'),
(24, N'bb000024-0000-0000-0000-000000000024', N'Gwangjin-gu'),
(25, N'bb000025-0000-0000-0000-000000000025', N'Dongjak-gu')
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO

-- ---- Amenities ------------------------------------------
SET IDENTITY_INSERT [dbo].[Amenities] ON
INSERT [dbo].[Amenities] ([ID],[GUID],[Name],[IconName]) VALUES
(1,  N'37647c60-15aa-4a41-8af3-2583496919c9', N'Parking',            N'001-home.png'),
(2,  N'488716b5-9323-4335-85eb-e17b78b5ba64', N'Free Wifi',           N'028-connection.png'),
(3,  N'af861aa0-3828-4845-b013-2e0bb33a36e2', N'Room Service',        N'274-checkmark2.png'),
(4,  N'55091928-b7e2-4bd4-a42b-f80a94e4e1dc', N'Breakfast',           N'164-spoon-knife.png'),
(5,  N'0f502995-17f2-4f4d-8c80-7545f6b93ec7', N'Hair Styling Tools',  N'347-scissors.png'),
(6,  N'62161419-a17b-49f9-bca8-a9063bd78b21', N'Sound System',        N'295-volume-high.png'),
(7,  N'4db627db-e0d8-4d7c-8549-5ace684b706f', N'Safety Box',          N'143-key2.png'),
(8,  N'129418ae-b767-4abf-9283-063f14c3fe86', N'Business Facilities', N'085-printer.png'),
(9,  N'271b3a3f-eb49-4fe9-b8a0-f61337cfc343', N'Laundry Services',    N'341-radio-checked.png'),
(10, N'dbf027c9-8aae-4990-a5ce-01b319d80fe1', N'Daily Newspaper',     N'005-newspaper.png'),
(11, N'd5010dae-314a-4cd8-bf6a-fbc53a8005d1', N'Entertainment',       N'018-music.png')
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO

-- ---- Attractions ----------------------------------
SET IDENTITY_INSERT [dbo].[Attractions] ON
INSERT [dbo].[Attractions] ([ID],[GUID],[AreaID],[Name],[Address]) VALUES
(1,  N'670c374a-5fe5-4065-9f1e-18ed5d7232d6', 1,  N'Dobongsan',                N'서울특별시 도봉구 도봉동'),
(2,  N'c21b75a4-089b-4f5b-bc24-fd89139dbf08', 2,  N'Cheongnyangni Station',    N'서울특별시 동대문구 전농동'),
(3,  N'500919eb-eb16-4456-816e-7fe606a8b2e4', 2,  N'Gyeongdong Market',        N'서울특별시 동대문구 제기동'),
(4,  N'eb14eefb-e3b3-45f2-96ef-c9199d043cd3', 2,  N'Hongneung Park',           N'서울특별시 동대문구 청량리동'),
(5,  N'436f48e0-27e8-48c5-b25e-d1a1bb7d5ef9', 3,  N'Bongsan Park',             N'서울특별시 은평구 봉산동'),
(6,  N'5124200e-dff6-40b8-a017-b93d69c18673', 3,  N'Gupabal Fall',             N'서울특별시 은평구 구파발동'),
(7,  N'571ceb35-139a-42bf-bde0-ef892b820428', 4,  N'Bukhansan National Park',  N'서울특별시 강북구 우이동'),
(8,  N'e1bab1d7-1b86-46a4-a6d2-0888ccbc0f72', 4,  N'Dream Forest',             N'서울특별시 강북구 번동'),
(9,  N'43ccbfce-9485-4cf1-aff0-8ccf1e23fa21', 5,  N'Cheonhodong Park',         N'서울특별시 강동구 천호동'),
(10, N'3d52550e-2722-4205-a259-4a076988dcbd', 5,  N'Dunchun-dong Marsh Area',  N'서울특별시 강동구 둔촌동'),
(11, N'48be80bf-b6e7-4f80-b5d6-60195fa2490f', 5,  N'Kildong Ecological Park',  N'서울특별시 강동구 길동'),
(12, N'c787224d-d300-444a-9cda-b0a57774fd61', 5,  N'Saetmaeul Park',           N'서울특별시 강동구 암사동'),
(13, N'05fbe1c9-ce6b-49f5-a907-4930b68a8459', 6,  N'Bongeunsa Temple',         N'서울특별시 강남구 삼성동'),
(14, N'9f7ebf02-134d-406b-99a2-8070b57c4cab', 6,  N'COEX Mall',                N'서울특별시 강남구 삼성동'),
(15, N'68a11502-6f31-4d0b-823e-9bb00078013a', 6,  N'Dosan Park',               N'서울특별시 강남구 신사동'),
(16, N'b12281c8-6674-4bc4-964c-08a42962ce34', 6,  N'Gangnam Station',          N'서울특별시 강남구 역삼동'),
(17, N'b3c593e9-1e54-4e2e-a1a7-7f289213d988', 6,  N'Garosu-gil',               N'서울특별시 강남구 신사동'),
(18, N'37a5d8d7-6c76-47ab-8afe-c2fc248b8469', 6,  N'Kukkiwon',                 N'서울특별시 강남구 역삼동'),
(19, N'de4533ae-571f-4ea6-9469-b55548e1215b', 6,  N'Teheranno',                N'서울특별시 강남구 테헤란로'),
(20, N'763d45bc-035c-4bfc-92cf-2b19c63b6c94', 6,  N'Yangjaecheon',             N'서울특별시 강남구 양재동'),
(21, N'08be9b58-c945-4913-b80f-4600320d6823', 7,  N'Gimpo International Airport', N'서울특별시 강서구 공항동'),
(22, N'1c4f1f28-e448-4cf6-95a0-c64ad3539fe7', 7,  N'Heojun Museum',            N'서울특별시 강서구 가양동')
SET IDENTITY_INSERT [dbo].[Attractions] OFF
GO

-- ---- CancellationPolicies --------------------------------
SET IDENTITY_INSERT [dbo].[CancellationPolicies] ON
INSERT [dbo].[CancellationPolicies] ([ID],[GUID],[Name],[PlatformCommissionRate]) VALUES
(1, N'6cc083f6-c039-4ac2-acb2-12a0058b0f73', N'Flexible',  7.00),
(2, N'490c3c20-8974-4e69-96bf-3066c25d06ba', N'Moderate', 15.00),
(3, N'7bfa6503-471f-45c1-ab22-796db8f9d71d', N'Strict',   25.00)
SET IDENTITY_INSERT [dbo].[CancellationPolicies] OFF
GO

-- ---- CancellationRefundFees ------------------------------
SET IDENTITY_INSERT [dbo].[CancellationRefundFees] ON
INSERT [dbo].[CancellationRefundFees] ([ID],[GUID],[CancellationPolicyID],[DaysLeft],[PenaltyPercentage]) VALUES
-- Flexible
(1,  N'a036741a-5582-44a0-a20d-5484ce3fa570', 1, 7,   5.00),
(2,  N'4d5e9b0f-f751-42af-a00a-2423503d857d', 1, 6,  10.00),
(3,  N'335c5e75-0dc6-4a80-9b35-647b37e4bafc', 1, 5,  15.00),
(4,  N'372e4722-c717-4a05-8ecb-a4dfedd91bff', 1, 4,  15.00),
(5,  N'844a1700-c757-4b61-90bb-9450f94cb421', 1, 3,  20.00),
(6,  N'c67f3725-ba45-4f72-9b1e-b9cced1b1ac0', 1, 2,  20.00),
(7,  N'67082379-db2f-4d21-a9b8-fc8fdf53b0e9', 1, 1,  30.00),
(8,  N'ea887a9b-ccb4-4593-ba4f-63fa62606c1e', 1, 0,  40.00),
-- Moderate
(9,  N'36bd39c8-4c11-4a28-ab04-0a87562bd3bf', 2, 7,  10.00),
(10, N'34336eec-c4de-4a73-8e9f-7577e133e9a0', 2, 6,  15.00),
(11, N'3341968c-c849-4d06-a558-0061e01ef7fc', 2, 5,  20.00),
(12, N'9da45846-7d13-4322-a763-712189cefdc8', 2, 4,  20.00),
(13, N'410f8f56-12f4-4279-a7a8-420a8e7b60ad', 2, 3,  30.00),
(14, N'06dff31f-6fbb-4fc4-8988-ce6a2747174b', 2, 2,  35.00),
(15, N'cdf6b818-8052-4ca4-91eb-84a566b92eba', 2, 1,  40.00),
(16, N'754a6481-5d39-4b36-b370-4c7220f5aa06', 2, 0,  45.00),
-- Strict
(17, N'725341c0-538b-44c1-b02a-92914a67ca42', 3, 7,  20.00),
(18, N'14ed982b-9ea1-4d5d-aa75-eaf86ff3bdc7', 3, 6,  25.00),
(19, N'8f9b8930-b65c-44b5-bb78-5fbae6afea29', 3, 5,  30.00),
(20, N'9a5f70cb-befb-4d4b-a974-37757866f862', 3, 4,  35.00),
(21, N'4299d7aa-d692-4dac-b952-0a9caae24bdc', 3, 3,  40.00),
(22, N'55ab294f-d38c-47e1-8f3c-830b8f26cf56', 3, 2,  50.00),
(23, N'fa09e103-f8d1-4863-bdb8-fb8cb26be048', 3, 1,  90.00),
(24, N'1fc75f78-462a-4436-9a86-96a419a9db44', 3, 0, 100.00)
SET IDENTITY_INSERT [dbo].[CancellationRefundFees] OFF
GO

-- ---- Coupons --------------------------------------------
SET IDENTITY_INSERT [dbo].[Coupons] ON
INSERT [dbo].[Coupons] ([ID],[GUID],[CouponCode],[DiscountPercent],[MaximumDiscountAmount],
                         [StartDate],[ExpirationDate],[MaxUsageCount],[IsActive]) VALUES
(1, N'cf3292fe-8636-400f-8c3f-2b5c5551f004', N'Welcome15', 15.0, 10.00,  '2022-01-01', '2027-12-31', NULL,  1),
(2, N'0ce0b94f-112c-42dc-a110-314c5ba1308b', N'Holiday',    5.0, 100.00, '2022-01-01', '2027-12-31', 500,   1),
(3, N'4a33cb47-ac38-48f8-88d2-97f103ad75a7', N'Seoul',      2.0, 200.00, '2022-01-01', NULL,          NULL,  1)
SET IDENTITY_INSERT [dbo].[Coupons] OFF
GO

-- ---- Users--------
-- Gender: 0=Unknown  1=Male  2=Female  3=Other
-- UserType: 1=admin  2=host  3=guest
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID],[GUID],[UserTypeID],[Username],[Password],[FullName],
                       [Email],[Gender],[BirthDate],[FamilyCount],[IsActive]) VALUES
-- Admin
(1,  N'3fa2814d-a355-4169-9a23-b3476f8c7083', 1, N'sonia1980', N'1980',
     N'Sonia Edvard',        N'sonia@seoulstay.com',    1, '1980-12-02', 1, 1),
-- Hosts
(2,  N'b36658f2-e2e7-4a89-a60f-0861b77640cb', 2, N'sirvard',  N'9090',
     N'Nerses Sirvard',      N'sirvard@email.com',      1, '1975-01-01', 5, 1),
(3,  N'2fd71d03-5d51-4015-a4b2-2f337692d919', 2, N'mahdi',    N'1234',
     N'Mahdi Jokar',         N'mahdi@email.com',        1, '1985-02-03', 3, 1),
(4,  N'd049f07f-85dd-4e2c-b0ae-7f3339f75483', 2, N'minseo',   N'7890',
     N'Min-Seo Young-Ho',    N'minseo@email.com',       1, '1990-04-04', 1, 1),
(6,  N'64fdd587-2976-4e62-aa4d-341cfcdfcba2', 2, N'minju',    N'0000',
     N'Minju Olp',           N'minju@email.com',        2, '1991-05-06', 3, 1),
-- Guests 
(7,  N'3fe65e94-4f44-4c15-b88f-549a92e832b4', 3, N'bayan',    N'9580',
     N'Bayan Karim',         N'bayan@email.com',        2, '1992-09-09', 1, 1),
(8,  N'cc000008-0000-0000-0000-000000000008', 3, N'tomkim',   N'pass01',
     N'Tom Kim',             N'tom@email.com',          1, '1995-11-05', 1, 1),
(9,  N'cc000009-0000-0000-0000-000000000009', 3, N'saralee',  N'pass02',
     N'Sara Lee',            N'sara@email.com',         2, '1993-04-18', 3, 1),
(10, N'cc000010-0000-0000-0000-000000000010', 3, N'jiwon',    N'pass03',
     N'Park Jiwon',          N'jiwon@email.com',        2, '1997-08-20', 2, 1),
(11, N'cc000011-0000-0000-0000-000000000011', 3, N'yusuf',    N'pass04',
     N'Yusuf Al-Rashid',     N'yusuf@email.com',        1, '1988-03-12', 4, 1),
(12, N'cc000012-0000-0000-0000-000000000012', 3, N'claire',   N'pass05',
     N'Claire Dubois',       N'claire@email.com',       2, '1994-07-30', 1, 1),
(13, N'cc000013-0000-0000-0000-000000000013', 3, N'alexwang', N'pass06',
     N'Alex Wang',           N'alexwang@email.com',     1, '1991-12-15', 2, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

-- ---- Items ----------------------------------------------
SET IDENTITY_INSERT [dbo].[Items] ON
INSERT [dbo].[Items] ([ID],[GUID],[UserID],[ItemTypeID],[AreaID],[Title],[Capacity],[NumberOfBeds],
    [NumberOfBedrooms],[NumberOfBathrooms],[ExactAddress],[ApproximateAddress],[Description],[HostRules],
    [MinimumNights],[MaximumNights]) VALUES
(2,  N'a09423d2-25e5-4ca2-978f-03af1d7bf7fd', 2, 1, 15, N'Superior Cozy Home J',      5, 5, 1, 1,
     N'562-1 Punggok-ri, Gagok-myeon, Seocho-gu',         N'Seocho-gu, Gagok-myeon',
     N'With 1 bedroom, this air-conditioned apartment features 1 bathroom with a bidet, a bath or shower and slippers.',
     N'Pets are not allowed.', 1, 10000),
(3,  N'63de0bd5-c079-4036-be6e-b9bc9afa5e56', 4, 5, 1, N'Lee Jae Guesthouse',         4, 3, 1, 0,
     N'583 Jisan-ri, Habuk-myeon, Dobong-gu',              N'Dobong-gu',
     N'Comfortable as your home. Free WiFi, 6.4 km from Hongik University.',
     N'Smoking is not allowed.', 1, 10000),
(4,  N'aca50fbb-def0-4657-af83-3a30cde5db51', 3, 1, 2, N'Lee Jae Sweet House',        3, 3, 1, 0,
     N'126-3 Gaeksa-ri, Paengseong-eup, Dongdaemun-gu',   N'Dongdaemun-gu',
     N'Located in Seoul, 2.9 km from Ewha Women''s University and 3.1 km from Seoul Station.',
     N'Pets are not allowed.', 1, 10000),
(5,  N'158a1a1e-e75d-492b-9f76-65c8fbb539d5', 2, 3, 15, N'Hongdae Min House 2',       5, 5, 3, 1,
     N'123 Nogok-ri, Yangseong-myeon, Seocho-gu',          N'Seocho-gu, Yangseong-myeon',
     N'In the Mapo-gu district of Seoul, close to Hongik University Station.',
     N'Pets are not allowed.', 1, 10000),
(7,  N'8cb82712-d0b8-420e-a6c6-84c9a5ec0300', 3, 2, 1, N'Lovely House Dobong',        5, 5, 2, 0,
     N'198-10 Uijeongbu 1(il)-dong, Dobong-gu',            N'Dobong-gu',
     N'Some of the units include satellite flat-screen TV, a fully equipped kitchen.',
     N'Pets are not allowed.', 1, 10000),
(8,  N'950ef823-36f2-4c27-8286-e47d9d62ae9f', 6, 3, 15, N'HONGDAE HELEN''S HOUSE',   6, 6, 3, 2,
     N'200-9 Mui-ri, Bongpyeong-myeon, Seocho-gu',         N'Seocho-gu',
     N'Located in Seoul with Hongik University Station nearby. Free WiFi and free private parking.',
     N'Pets are not allowed. Smoking is not allowed.', 1, 10000),
(9,  N'87e8d2de-7460-46fe-bbbe-fd4ca0fb35df', 6, 1, 4, N'Residence Unicorn',          7, 7, 2, 2,
     N'1135-6 Ingye-dong, Gangbuk-gu',                     N'Gangbuk-gu',
     N'Ewha Women''s University is 3.5 km from the apartment, while Seoul Station is 5.6 km away.',
     N'Pets are not allowed.', 1, 10000),
(10, N'817c6887-ce04-4b27-8b9f-fbbff8b94f92', 6, 1, 4, N'Eve Hongdae Studio',         2, 1, 1, 0,
     N'228-87 Micheon-ri, Munui-myeon, Gangbuk-gu',        N'Gangbuk-gu',
     N'Cozy studio with city views, free WiFi and free private parking.',
     N'Pets are not allowed.', 1, 10000),
(11, N'666af311-cb9a-48c3-bd97-7aede1416663', 6, 1, 5, N'Samsung Coex Gangnam Suite', 2, 1, 1, 1,
     N'900-13 Hwajeong-dong, Gangnam-gu',                  N'Gangnam-gu',
     N'All units are air-conditioned and feature a flat-screen TV, a living room.',
     N'Pets are not allowed. Smoking is not allowed.', 1, 10000),
(12, N'2d635d50-ffed-4aab-b26d-4f75ec823a7a', 3, 3, 15, N'White Linen House',         4, 2, 1, 1,
     N'669-23 Ganeung 1(il)-dong, Seocho-gu',              N'Seocho-gu',
     N'Warm and welcoming. Perfect for families or small groups.',
     N'Pets are not allowed.', 1, 10000),
(13, N'e2dec1aa-845e-4bd4-82df-30604166b3a5', 3, 5, 3, N'Gangnam 220SQM Tower',       4, 2, 1, 1,
     N'3 Wonam-ri, Namsa-myeon, Eunpyeong-gu',             N'Eunpyeong-gu',
     N'Spacious apartment in Eunpyeong. Kitchen, private bathroom, washing machine.',
     N'Pets are not allowed.', 1, 10000),
(14, N'fb24cd7e-02cd-4d6c-b59e-dffd310c0769', 6, 5, 1, N'Gangnam Super-Luxury',       3, 2, 1, 1,
     N'106-3 Yangji-ri, Onam-eup, Dobong-gu',              N'Dobong-gu',
     N'1 min from attractions. Emart, Starbucks, convenience stores and local restaurants.',
     N'Pets are not allowed. Smoking is not allowed.', 1, 10000),
(15, N'39ba4544-6858-4cb3-a2a3-56c0873df866', 2, 1, 2, N'Gangnam Penthouse 145sqm',   5, 3, 1, 1,
     N'251-10 Jugyo-dong, Dongdaemun-gu',                  N'Dongdaemun-gu',
     N'City views, complimentary WiFi and private parking. Near COEX.',
     N'Pets are not allowed.', 1, 10000),
(17, N'27d85526-9762-43fa-a928-e7ce6dd6cc8a', 3, 2, 4, N'Eden House Gangbuk',         5, 3, 1, 0,
     N'883-6 Dangye-dong, Gangbuk-gu',                     N'Gangbuk-gu',
     N'6.6 km from The Shilla Duty Free Shop. Nearest airport is Gimpo International.',
     N'Pets are not allowed.', 1, 10000),
(18, N'496c5c1a-3cb3-4777-ab59-dd9400a231cd', 3, 5, 2, N'Hongdae Residence',          5, 4, 1, 0,
     N'74 Sunae 3(sam)-dong, Dongdaemun-gu',               N'Dongdaemun-gu',
     N'Cozy and affordable. Close to public transport and shopping.',
     N'Pets are not allowed.', 1, 10000),
(19, N'd1639191-64a3-451a-b0a2-6bd1c37ee92d', 3, 5, 1, N'Hongdae Residence-2',        10, 7, 5, 3,
     N'130 Gangnam-dong, Dobong-gu',                       N'Dobong-gu',
     N'Spacious 5-bedroom property. Perfect for large groups.',
     N'Pets are not allowed.', 1, 10000),
(20, N'd2a108a1-32b2-4682-9a11-18131b436309', 3, 2, 2, N'Sweet House #2',             6, 6, 1, 1,
     N'353-4 Seongju-ri, Wongok-myeon, Dongdaemun-gu',    N'Dongdaemun-gu',
     N'Air-conditioned with flat-screen TV, dining area and kitchen.',
     N'Pets are not allowed.', 1, 10000),
(21, N'88221551-a3a1-4f6a-ab95-e3fd3556c6cb', 3, 5, 2, N'Hongdae Residence 3',        7, 5, 2, 2,
     N'672 Yongwon-ri, Seongnam-myeon, Dongdaemun-gu',    N'Dongdaemun-gu',
     N'3.2 km from Gangnam Station. 6-min walk from COEX Convention Centre.',
     N'Pets are not allowed.', 1, 10000),
(23, N'303e83b2-ac84-4464-a5fe-f6b9c8ad0e65', 4, 2, 15, N'Laon House Yeonnam',        3, 2, 2, 0,
     N'640-2 Gak-ri, Ochang-eup, Seocho-gu',              N'Seocho-gu',
     N'Quiet neighborhood, close to cafes and local markets.',
     N'Smoking is not allowed.', 1, 10000),
(24, N'dc2b584b-c91e-4a21-8af5-cbe03cd0e442', 4, 5, 15, N'Coopie House 2',            5, 4, 1, 1,
     N'36-1 Indong-ri, Gangdong-myeon, Seocho-gu',        N'Seocho-gu',
     N'Well-equipped kitchen, private bathroom. Near public transport.',
     N'Pets are not allowed.', 1, 10000),
(25, N'1d35340d-77e2-41f7-a341-2067600c9340', 4, 3, 15, N'Orakai Insadong Suites',    10, 8, 5, 3,
     N'337 Ungjin-dong, Seocho-gu',                       N'Seocho-gu',
     N'Luxury suites in the heart of Seoul. All amenities included.',
     N'Pets are not allowed.', 1, 10000)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO

-- ---- ItemAmenities (mẫu) --------------------------------
SET IDENTITY_INSERT [dbo].[ItemAmenities] ON
INSERT [dbo].[ItemAmenities] ([ID],[GUID],[ItemID],[AmenityID]) VALUES
(1,  N'd71e48f1-a38f-40e5-9185-54635f8276b6',  5, 1),
(2,  N'ca76fcd9-120c-42e9-8e09-fe90010050bf',  7, 1),
(3,  N'ddea27c2-b94a-410d-b047-2b695b237b9a', 12, 1),
(4,  N'921ab7f2-1396-446e-a894-b0b20f1cc06a', 15, 1),
(5,  N'd209e504-4358-48c1-804e-3f8d4d3d43a5',  5, 2),
(6,  N'9f510a52-a328-4d02-b027-20c0a32a035b',  9, 2),
(7,  N'5abf5036-bb46-49ba-9496-3f2ea4184a17', 11, 2),
(8,  N'f5adfcfd-12ea-4b7b-bf2a-ba5efb95d676', 12, 2),
(9,  N'692e5c75-7af9-461b-81fe-6b210f848081',  2, 3),
(10, N'a3cac984-9b12-4b60-99eb-35caa3af4b8e',  3, 3),
(11, N'99613d37-0211-4025-8382-d4ce32c67f1e',  9, 3),
(12, N'368a0576-e396-4fdb-9601-bdaab9a3c579', 12, 3),
(13, N'a1549613-4487-4a6c-b114-cf7e0a4177dc',  3, 4),
(14, N'b42dfdb6-06c4-4885-b9db-eaddb1aa6a80',  4, 4),
(15, N'07780b14-8d8c-4e50-8e49-50685fd544b0',  5, 4),
(16, N'52936b74-624b-4689-8920-a67db694c256',  7, 4),
(17, N'c8567cbf-510b-4b36-a73b-029dfd5b1997',  9, 4),
(18, N'4c6f8014-4148-448e-93bc-ba9efec7997b', 12, 4),
(19, N'5293d5c1-0d8d-4e04-ad30-262a4cb433dc', 14, 4),
(20, N'54f5330f-c6a9-463e-a59b-ad9771cd74c6', 17, 4)
SET IDENTITY_INSERT [dbo].[ItemAmenities] OFF
GO

-- ---- ItemPrices -----------------------------------
SET IDENTITY_INSERT [dbo].[ItemPrices] ON
INSERT [dbo].[ItemPrices] ([ID],[GUID],[ItemID],[Date],[Price],[CancellationPolicyID]) VALUES
(1,  N'dfe5de3b-8b77-43c2-bfff-046dc70a5e9e', 18, '2022-10-10', 100.00, 1),
(2,  N'd85c42a1-417d-40df-b623-c442fe49abe1', 18, '2022-10-11', 100.00, 2),
(3,  N'e66af364-98c4-4295-9780-9bbf4e11d01a', 18, '2022-10-12', 100.00, 2),
(4,  N'0d3b2c92-9d60-48af-a65d-7a7438f23169', 18, '2022-10-13', 100.00, 2),
(5,  N'c4a90090-e2d7-44be-9d30-e07421241afb', 18, '2022-10-14', 100.00, 1),
(6,  N'0cb62368-696d-415c-a73b-2d673142d44b', 18, '2022-10-15', 100.00, 1),
(7,  N'38ef2158-a3e8-4f82-8144-c6dc3d122013', 18, '2022-10-16', 100.00, 1),
(8,  N'cd7b6b28-dbbb-4663-8866-ba4905417261', 18, '2022-10-17', 100.00, 2),
(9,  N'1029d7b0-0d2c-4b77-a822-be4ee4c0686b', 18, '2022-10-18', 140.00, 3),
(10, N'a334171b-350f-4561-a29a-caaf78456710', 18, '2022-10-19', 145.00, 2),
(11, N'6b2d6323-f03c-471d-bfd9-75cbee33ae0f', 18, '2022-10-20', 140.00, 1),
(12, N'0a578d91-0643-4372-b1c9-9adac5462c1d', 19, '2022-10-22', 200.00, 2),
(13, N'45897c24-7fc2-4625-b105-ea5015207e74', 19, '2022-10-23', 210.00, 2),
(14, N'8f28a345-8ae1-4f27-ba55-92813218d37b', 19, '2022-10-24', 190.00, 1),
(15, N'de716cf0-997a-4882-b543-833c4642085d', 19, '2022-10-25', 190.00, 1),
(16, N'878bf0ee-36ff-4928-948b-1c80598b482c', 19, '2022-10-26', 190.00, 1),
(17, N'9010adcc-c977-4480-96e0-d321ca3cea1f', 19, '2022-10-27', 190.00, 3),
(18, N'5f29010b-4239-4fbe-bee4-899ab2aee960', 19, '2022-10-28', 190.00, 3),
(19, N'b2dbf15e-2df2-4e50-b154-5a145ba6b45e', 19, '2022-10-29', 190.00, 1),
(20, N'b9618ae7-8bc1-4cac-a696-12c6c54ebcf7', 19, '2022-10-30', 270.00, 1),
(21, N'04599602-bddb-4cd9-9298-21350193bee1', 19, '2022-10-31', 290.00, 1)
SET IDENTITY_INSERT [dbo].[ItemPrices] OFF
GO

-- ---- Transactions  ---------------------------------
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions] ([ID],[UserID],[TransactionTypeID],[Amount],[TransactionDate],[GatewayReturnID]) VALUES
(1, 8,  1, 300.00, '2022-10-12', N'GW-2022-001'),
(2, 9,  1, 570.00, '2022-10-22', N'GW-2022-002'),
(3, 10, 1, 200.00, '2022-10-14', N'GW-2022-003'),
(4, 11, 1, 400.00, '2022-10-25', N'GW-2022-004'),
(5, 12, 1, 145.00, '2022-10-19', N'GW-2022-005')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO

-- ---- Bookings -------------------------------------
SET IDENTITY_INSERT [dbo].[Bookings] ON
INSERT [dbo].[Bookings] ([ID],[GUID],[UserID],[ItemID],[CheckInDate],[CheckOutDate],
    [NumberOfGuests],[PricePerNight],[TotalPrice],[DiscountAmount],[FinalPrice],
    [CancellationPolicyID],[BookingStatus],[TransactionID]) VALUES
(1, N'bk000001-0000-0000-0000-000000000001', 8,  18, '2022-10-12', '2022-10-15', 2, 100.00, 300.00,  0.00, 300.00, 1, 'Completed', 1),
(2, N'bk000002-0000-0000-0000-000000000002', 9,  19, '2022-10-22', '2022-10-25', 4, 190.00, 570.00,  0.00, 570.00, 2, 'Completed', 2),
(3, N'bk000003-0000-0000-0000-000000000003', 10, 18, '2022-10-14', '2022-10-16', 1, 100.00, 200.00, 10.00, 190.00, 1, 'Completed', 3),
(4, N'bk000004-0000-0000-0000-000000000004', 11, 19, '2022-10-25', '2022-10-27', 3, 190.00, 380.00, 20.00, 360.00, 2, 'Confirmed', 4),
(5, N'bk000005-0000-0000-0000-000000000005', 12, 18, '2022-10-18', '2022-10-19', 1, 140.00, 140.00,  0.00, 140.00, 3, 'Cancelled', NULL)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO

-- ---- BookingStatusHistory  -------------------------
SET IDENTITY_INSERT [dbo].[BookingStatusHistory] ON
INSERT [dbo].[BookingStatusHistory] ([ID],[GUID],[BookingID],[OldStatus],[NewStatus],[ChangedByUserID]) VALUES
(1, N'bsh00001-0000-0000-0000-000000000001', 1, NULL,        'Pending',   1),
(2, N'bsh00002-0000-0000-0000-000000000002', 1, 'Pending',   'Confirmed', 1),
(3, N'bsh00003-0000-0000-0000-000000000003', 1, 'Confirmed', 'CheckedIn', 1),
(4, N'bsh00004-0000-0000-0000-000000000004', 1, 'CheckedIn', 'Completed', 1),
(5, N'bsh00005-0000-0000-0000-000000000005', 5, NULL,        'Pending',   1),
(6, N'bsh00006-0000-0000-0000-000000000006', 5, 'Pending',   'Cancelled', 12)
SET IDENTITY_INSERT [dbo].[BookingStatusHistory] OFF
GO

-- ---- BookingCoupons --------------------------------
SET IDENTITY_INSERT [dbo].[BookingCoupons] ON
INSERT [dbo].[BookingCoupons] ([ID],[GUID],[BookingID],[CouponID],[DiscountApplied]) VALUES
(1, N'bc000001-0000-0000-0000-000000000001', 3, 1, 10.00),
(2, N'bc000002-0000-0000-0000-000000000002', 4, 2, 20.00)
SET IDENTITY_INSERT [dbo].[BookingCoupons] OFF
GO

-- ---- Reviews  --------------------------------------
SET IDENTITY_INSERT [dbo].[Reviews] ON
INSERT [dbo].[Reviews] ([ID],[GUID],[BookingID],[ReviewerID],[RevieweeID],[ItemID],[Rating],[Comment]) VALUES
-- Review chỗ ở (ItemID NOT NULL, RevieweeID NULL)
(1, N'rv000001-0000-0000-0000-000000000001', 1, 8,  NULL, 18, 5, N'Amazing stay! Clean, cozy and great location.'),
(2, N'rv000002-0000-0000-0000-000000000002', 2, 9,  NULL, 19, 4, N'Very spacious. Great for families.'),
(3, N'rv000003-0000-0000-0000-000000000003', 3, 10, NULL, 18, 5, N'Perfect little studio. Will come back!'),
-- Review host (RevieweeID NOT NULL, ItemID NULL)
(4, N'rv000004-0000-0000-0000-000000000004', 1, 8,  3, NULL, 5, N'Host was very responsive and helpful.'),
(5, N'rv000005-0000-0000-0000-000000000005', 2, 9,  3, NULL, 4, N'Good communication throughout the stay.')
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
