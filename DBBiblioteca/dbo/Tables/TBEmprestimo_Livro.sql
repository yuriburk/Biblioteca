CREATE TABLE [dbo].[TBEmprestimo_Livro] (
    [Emprestimo_Id] INT NOT NULL,
    [Livro_Id]      INT NOT NULL,
    CONSTRAINT [FK_TBEmprestimo_Livro_TBEmprestimo] FOREIGN KEY ([Emprestimo_Id]) REFERENCES [dbo].[TBEmprestimo] ([IdEmprestimo]),
    CONSTRAINT [FK_TBEmprestimo_Livro_TBLivro] FOREIGN KEY ([Livro_Id]) REFERENCES [dbo].[TBLivro] ([IdLivro])
);

