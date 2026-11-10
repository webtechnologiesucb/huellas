IF OBJECT_ID(N'dbo.refresh_tokens', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.refresh_tokens
    (
        id INT IDENTITY(1,1) NOT NULL,
        user_email VARCHAR(150) NOT NULL,
        token VARCHAR(64) NOT NULL,
        is_valid BIT NOT NULL,
        created_at DATETIME2 NOT NULL,
        expires_at DATETIME2 NOT NULL,
        CONSTRAINT PK_refresh_tokens PRIMARY KEY (id),
        CONSTRAINT UX_refresh_tokens_user_email UNIQUE (user_email)
    );
END;
