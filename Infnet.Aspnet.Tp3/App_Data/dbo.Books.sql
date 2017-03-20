CREATE TABLE [dbo].[Books] (
    [Id]        INT           NOT NULL IDENTITY,
    [Title]     VARCHAR (255) NOT NULL,
    [Author]    VARCHAR (255) NOT NULL,
    [Publisher] VARCHAR (255) NOT NULL,
    [Year]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

