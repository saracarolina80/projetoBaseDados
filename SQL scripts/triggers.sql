CREATE TRIGGER CheckStockQuantity
ON Otica_Stock FOR INSERT, UPDATE
AS
BEGIN
  IF EXISTS (
    SELECT *
    FROM Otica_Stock
    WHERE quantidade < 0
  )
  BEGIN
    RAISERROR ('A quantidade em stock não pode ser negativa.', 16, 1);
    ROLLBACK TRANSACTION;
    RETURN;
  END;
END;
