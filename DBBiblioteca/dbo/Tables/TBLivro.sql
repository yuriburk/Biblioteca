CREATE TABLE [dbo].[TBLivro] (
    [IdLivro]        INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]         VARCHAR (100) NOT NULL,
    [Tema]           VARCHAR (50)  NOT NULL,
    [Autor]          VARCHAR (50)  NOT NULL,
    [Volume]         INT           NOT NULL,
    [DataPublicacao] DATETIME      NOT NULL,
    [Disponivel]     BIT           NOT NULL,
    CONSTRAINT [PK_TBLivro] PRIMARY KEY CLUSTERED ([IdLivro] ASC)
);

