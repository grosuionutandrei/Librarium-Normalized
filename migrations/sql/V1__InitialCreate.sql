USE Librarium
    GO

CREATE TABLE [Books] (
        [BookId] uniqueidentifier NOT NULL,
        [Title] nvarchar(500) NOT NULL,
        [Isbn] nvarchar(20) NOT NULL,
        [PublicationYear] int NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
    );

    CREATE UNIQUE INDEX [IX_Books_Isbn] ON [Books] ([Isbn]);



    CREATE TABLE [Members] (
        [MemberId] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [Email] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Members] PRIMARY KEY ([MemberId])
    );

    CREATE UNIQUE INDEX [IX_Members_Email] ON [Members] ([Email]);


    CREATE TABLE [Loans] (
        [LoanId] uniqueidentifier NOT NULL,
        [MemberId] uniqueidentifier NOT NULL,
        [BookId] uniqueidentifier NOT NULL,
        [LoanDate] datetime2 NOT NULL,
        [ReturnDate] datetime2 NULL,
        CONSTRAINT [PK_Loans] PRIMARY KEY ([LoanId]),
        CONSTRAINT [FK_Loans_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Loans_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([MemberId]) ON DELETE NO ACTION
    );

    CREATE INDEX [IX_Loans_MemberId] ON [Loans] ([MemberId]);
    CREATE INDEX [IX_Loans_BookId] ON [Loans] ([BookId]);



