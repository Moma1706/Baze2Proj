-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE vrati_teren_sa_najvecim_brojem_gledalaca
	@retVal varchar(max) output
AS
BEGIN
	declare @Naziv_t varchar(max)
	declare @BrojGledalaca_t int
	declare @Mesto_t varchar(max)

	select @Naziv_t = t.Naziv, @BrojGledalaca_t =  max(t.BrojGledalaca), @Mesto_t = t.Mesto from Terens t group by t.Naziv, t.Mesto

	set @retVal = @Naziv_t;
END
