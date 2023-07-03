USE [TECHNICALASSESSMENT]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListBook]    Script Date: 7/3/2023 3:04:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_ListBookByAuthor]
	--Declare
	@PageNumber INT ,
     @PageSize INT ,
     @sort varchar(50)  ,
	 @StrSearch varchar(max)
	 
AS
	 DECLARE  @ErrMsg NVARCHAR(max),
			 @sql varchar(max),
			 @v_Returnvalue INT, @lng_ProfileId bigint

		BEGIN TRY
	 SET NOCOUNT ON;
		BEGIN TRANSACTION	

BEGIN 
		  set @StrSearch=ltrim(rtrim(@StrSearch))
		  
  set @sql='    WITH OrderedSet  
AS (
SELECT u.BookID,u.Publisher,u.Title,u.AuthorLastName,u.AuthorFirstName,u.Price FROM  (
	select t.BookID,t.Publisher, t.Title, t.AuthorLastName, t.AuthorFirstName, t.Price from Book t) as u'
  if(@StrSearch is not null and @StrSearch <> '')begin
     set @sql +=' where u.Publisher like ''%' + @StrSearch +'%'' or u.Title like ''%' + @StrSearch +'%'' or u.AuthorLastName like ''%' + @StrSearch +'%'' or u.AuthorFirstName like ''%' + @StrSearch +'%'' or u.Price like ''%' + @StrSearch +'%'''
  end
  set @sql +='  
)SELECT 
OrderedSet.BookID
,OrderedSet.Publisher
,OrderedSet.Title
,OrderedSet.AuthorLastName
,OrderedSet.AuthorFirstName
,OrderedSet.Price
FROM OrderedSet '

set @sql +='  ORDER BY OrderedSet.AuthorFirstName    
OFFSET('+cast(@PageNumber as varchar(100)) +'- 1) * '+cast(@PageSize as varchar(100))+' ROWS  
FETCH NEXT '+cast(@PageSize as varchar(100))+' ROWS ONLY OPTION (RECOMPILE);' ;
					 exec (@sql)
         END
		 	COMMIT
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0 
            ROLLBACK

        DECLARE @ErrSeverity INT,
            @ErrStoredProcedure NVARCHAR(400)

        SELECT  @ErrMsg = ERROR_MESSAGE(),
                @ErrSeverity = ERROR_SEVERITY(),
                @ErrStoredProcedure = ERROR_PROCEDURE()
  
        SELECT  @ErrMsg

	END CATCH


