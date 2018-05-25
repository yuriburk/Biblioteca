CREATE TABLE [dbo].[TBEmprestimo] (
    [IdEmprestimo]  INT          IDENTITY (1, 1) NOT NULL,
    [NomeCliente]   VARCHAR (50) NOT NULL,
    [DataDevolucao] DATETIME     NOT NULL,
    CONSTRAINT [PK_TBEmprestimo] PRIMARY KEY CLUSTERED ([IdEmprestimo] ASC)
);

