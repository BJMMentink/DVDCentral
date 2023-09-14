Begin
    INSERT INTO [dbo].[tblOrderItem] ([Id], [OrderId], [MovieId], [Quantity], [Cost])
    VALUES
        (1, 1, 1, 2, 25.98),
        (2, 1, 2, 1, 9.99),
        (3, 2, 3, 3, 44.97),
        (4, 3, 1, 1, 12.99)
End