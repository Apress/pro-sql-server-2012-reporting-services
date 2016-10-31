CREATE FUNCTION dbo.fn_MVParam(@RepParam nvarchar(4000), @Delim char(1)= ',')
RETURNS @Values TABLE (Param nvarchar(4000))AS
    BEGIN
    DECLARE @chrind INT
    DECLARE @Piece nvarchar(4000)
    SELECT @chrind = 1
    WHILE @chrind > 0
        BEGIN
            SELECT @chrind = CHARINDEX(@Delim,@RepParam)
            IF @chrind  > 0
                SELECT @Piece = LEFT(@RepParam,@chrind - 1)
            ELSE
                SELECT @Piece = @RepParam
            INSERT  @Values(Param) VALUES(@Piece)
            SELECT @RepParam = RIGHT(@RepParam,LEN(@RepParam) - @chrind)
            IF LEN(@RepParam) = 0 BREAK
    END
    RETURN
END
