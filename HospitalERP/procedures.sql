/****** Object:  StoredProcedure [dbo].[uspAppointments_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAppointments_Add] @patient_id int, @doctor_id int, @meet_date datetime, @status smallint As
 DECLARE @Ret int;
 DECLARE @token int;
 SET @Ret = -1;
 IF Exists (SELECT 1 FROM Appointments WHERE patient_id = @patient_id AND doctor_id=@doctor_id AND meet_date=@meet_date AND status=@status)
 BEGIN
  SET @Ret = 0;  
 END
 ELSE
 BEGIN
 SELECT @token=(ISNULL(MAX(token),0)+ 1) From Appointments WHERE meet_date=@meet_date AND doctor_id=@doctor_id;
 INSERT INTO Appointments(patient_id, doctor_id, meet_date,token, [status])
  Values (@patient_id,@doctor_id,@meet_date,@token,@status);
 SET @Ret = SCOPE_IDENTITY();
 End
 SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspAppointments_GetForBilling]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAppointments_GetForBilling] @aid int AS
BEGIN
SELECT a.id, a.patient_id,  a.doctor_id, a.meet_date,p.patient_number, dbo.svf_FormatName(p.first_name, p.last_name) as patient_name, dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name, a.token, ISNULL(b.bill_balance,0) as dues, s.name as status, a.notes,  p.address, p.city, p.state, p.zip, p.dob, dbo.svf_GetAge(p.dob) as age 
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status s on a.status=s.id 
LEFT JOIN (SELECT patient_id, bill_balance FROM Billing WHERE id IN (SELECT MAX(id) FROM Appointments WHERE bill_status=2 OR bill_status=3 AND bill_type=2 GROUP BY patient_id)) as b ON b.patient_id=a.patient_id 
WHERE a.id=@aid ORDER BY id,patient_number;
END

GO
/****** Object:  StoredProcedure [dbo].[uspAppointments_GetForDateDoc]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[uspAppointments_GetForDateDoc] @meet_date datetime, @doctor_id int, @status smallint AS
BEGIN
DECLARE @sql VARCHAR(max);
SET @sql = 'SELECT a.id, a.patient_id,  a.doctor_id, p.patient_number, dbo.svf_FormatName(p.first_name, p.last_name) as patient_name, dbo.svf_FormatDrName(d.first_name,d.last_name)  as doctor_name, a.token, am.prev_date,ISNULL(b.bill_balance,0) as dues, s.name as status 
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status s on a.status=s.id 
LEFT JOIN (SELECT patient_id, MAX(meet_date) as prev_date FROM Appointments WHERE id NOT IN (SELECT MAX(id)FROM Appointments GROUP BY patient_id) GROUP BY patient_id) as am ON am.patient_id=a.patient_id 
LEFT JOIN (SELECT patient_id, bill_balance FROM Billing WHERE id IN (SELECT MAX(id) FROM Appointments WHERE bill_status=2 OR bill_status=3 AND bill_type=2 GROUP BY patient_id)) as b ON b.patient_id=a.patient_id 
WHERE a.meet_date='''+ CAST(@meet_date AS varchar(20))+'''';

IF(@doctor_id >0)
BEGIN
SET @sql = @sql + ' AND  doctor_id =''' + CAST(@doctor_id AS varchar(20)) + '''';
END
IF(@status >0)
BEGIN
SET @sql = @sql + ' AND status =''' + CAST(@status AS varchar(20)) + ''' ';
END
SET @sql = @sql + ' ORDER BY id,patient_number';
EXEC(@sql);
END

GO
/****** Object:  StoredProcedure [dbo].[uspAppointmentStatus_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAppointmentStatus_Get]  AS
BEGIN
SELECT id,UPPER(name) as name FROM Appointment_Status WHERE active=1;
END

GO
/****** Object:  StoredProcedure [dbo].[uspBill_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspBill_Add] @appointment_id int, @patient_id int, @bill_amount decimal(10,3), @bill_type  int, @user_id int 
AS
 SET NOCOUNT ON;
 DECLARE @id AS int;
 DECLARE @billid AS int; 
 DECLARE @Ret int;
 SET @Ret = -1;
 
 DECLARE @prefix varchar(20);
 DECLARE @billnum varchar(20);
 
 SELECT @billid=(ISNULL(MAX(id),0)+ 1) From Billing;
 SELECT @prefix = op_value FROM Options WHERE op_name = 'BILLNUM_PREFIX'; 
 
 DECLARE @start int;
 SELECT   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'BILLNUM_START'; 
 
 SET @billid = @billid+@start;
 SET @billnum = @prefix + cast(@billid as varchar); 

 INSERT INTO dbo.Billing(appointment_id,bill_number,bill_date,patient_id,bill_amount,bill_paid,bill_balance,bill_type,bill_status, bill_created_userid)
 VALUES(@appointment_id,@billnum,GETDATE(),@patient_id,@bill_amount,0,@bill_amount,@bill_type,1,@user_id);

 SELECT @id = SCOPE_IDENTITY();
 
 SET @Ret = @id;
 

SELECT @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspBill_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspBill_Edit] @id int, @amount decimal(10,3), @paid decimal(10,3), @balance decimal(10,3), @status int, @user int
	AS	

	DECLARE @Ret int;
	DECLARE @appointment_id int;
	SELECT @appointment_id = appointment_id FROM Billing WHERE id=@id;
	SET @Ret = -1;
	UPDATE Billing SET bill_date=GETDATE(), bill_amount=@amount, bill_paid=@paid, bill_balance=@balance, bill_status=@status, bill_created_userid=@user WHERE [id]=@id 
	Update Appointments set [status]=4 WHERE id=@appointment_id;
	SET @Ret = @@ROWCOUNT;	
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspBill_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspBill_Get]  @appointment_id int, @patient_id int, @bill_type int AS
BEGIN
SELECT * FROM Billing WHERE appointment_id=@appointment_id AND patient_id=@patient_id AND bill_type=@bill_type AND bill_status!=5;
END
GO
/****** Object:  StoredProcedure [dbo].[uspBill_GetAllForApp]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspBill_GetAllForApp]  @appointment_id int, @patient_id int AS
BEGIN
SELECT b.*, UPPER(bt.name) as bill_type_name , UPPER(bs.name) as bill_status_name FROM Billing b 
JOIN Bill_Status bs ON b.bill_status=bs.id 
JOIN Bill_Types bt ON b.bill_type = bt.id   
WHERE b.appointment_id=@appointment_id AND b.patient_id=@patient_id 
ORDER BY id DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[uspBill_GetSingle]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspBill_GetSingle]  @id int AS
BEGIN
SELECT * FROM Billing WHERE id=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[uspBill_Procedures_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Create new procedures/tests
-- =============================================
CREATE PROCEDURE [dbo].[uspBill_Procedures_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT row_number() OVER (ORDER BY p.name) n, pp.id, p.name, p.description, pp.fee from Patient_Procedures pp 
	LEFT JOIN  Procedures p ON p.id=pp.procedure_id LEFT JOIN Procedure_Types t ON t.id=p.type 
	LEFT JOIN Procedure_Status st ON st.id=pp.status WHERE pp.appointment_id = @id AND (st.name='Completed' OR st.name='Undergoing')
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspBill_Search]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspBill_Search]  @SearchBy varchar(50), @SearchValue varchar(100), @date date, @datesearch bit AS
BEGIN
DECLARE @sql nvarchar(max);

DECLARE @date1 date;

SET @sql = 'SELECT b.id, p.id as patient_id, a.id as appointment_id, b.bill_number, CONVERT(date,b.bill_date) as bill_date, p.patient_number, CONCAT(p.first_name,'' '',p.last_name) as patient_name, 
b.bill_amount, b.bill_paid,  b.bill_balance, b.bill_type, b.bill_status, bt.name as bill_type_name , bs.name as bill_status_name   
FROM Patients p 
JOIN Appointments a ON p.id=a.patient_id 
JOIN Billing b ON b.appointment_id=a.id 
JOIN Bill_Types bt ON bt.id=b.bill_type 
JOIN Bill_Status bs ON bs.id=b.bill_status 
WHERE ';

IF(@SearchBy <> 'All')
BEGIN
SET @sql = @sql + @SearchBy + ' LIKE ''' + @SearchValue + '%''';
IF(@datesearch =1)
BEGIN
SET @sql = @sql + ' AND CONVERT(date,b.bill_date)=''' + CAST(@date as varchar(20)) + '''' ;
END
END
ELSE
BEGIN
SET @sql = @sql + ' CONVERT(date,b.bill_date)=''' + CAST(@date as varchar(20)) + '''' ;
END
SET @sql = @sql + ' ORDER BY b.bill_number DESC, p.patient_number ASC';
EXEC(@sql);
END
GO
/****** Object:  StoredProcedure [dbo].[uspBillStatus_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspBillStatus_Get]  AS
BEGIN
SELECT id,UPPER(name) as name FROM Bill_Status WHERE active=1;
END

GO
/****** Object:  StoredProcedure [dbo].[uspBillTypes_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspBillTypes_Get]  AS
BEGIN
SELECT id,UPPER(name) as name FROM Bill_Types WHERE active=1;
END

GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_AddProcedure]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspConsultationDet_AddProcedure] @patient_id int,@doctor_id int, @appointment_id int,  @procedure_id int, @notes text,
@fee decimal(10,3), @status smallint
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
	Begin
			INSERT INTO Patient_Procedures (patient_id, doctor_id, appointment_id, procedure_id, notes,fee,status)
		Values (@patient_id, @doctor_id, @appointment_id, @procedure_id, @notes,@fee, @status);
		set @Ret = 1;
	End
	select @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_EditProcedure]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspConsultationDet_EditProcedure] @id int,@patient_id int,@doctor_id int, @appointment_id int,  @procedure_id int, @notes text,
@fee decimal(10,3), @status smallint
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
	Begin
			UPDATE Patient_Procedures SET [patient_id]=@patient_id, [doctor_id]=@doctor_id, [appointment_id]=@appointment_id,
			procedure_id=@procedure_id, notes=@notes, status=@status, fee=@fee WHERE id=@id;
		
		set @Ret = 1;
	End
	select @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_EditProcedureFees]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[uspConsultationDet_EditProcedureFees] @id int,@fee decimal(10,3)
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
	Begin
			UPDATE Patient_Procedures SET  fee=@fee WHERE id=@id;
		
		set @Ret = 1;
	End
	select @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspConsultationDet_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT a.*, dbo.svf_FormatDrName(d.first_name, d.last_name) as doctor_name,  p.id as patient_id ,p.patient_number , dbo.svf_FormatName(p.first_name, p.last_name) as patient_name
,p.gender, p.nationality, p.phone, p.dob, p.address, p.city, p.state, p.zip, dbo.svf_GetAge(p.dob) as age, p.history, p.allergies, CONVERT(date, am.prev_date) as prev_date,b.bill_balance as dues, CAST(a.meet_date AS DATE)  as appointment_date, ast.name as status_name, ast.edit_lock as status_edit_lock 
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status ast ON a.status = ast.id
LEFT JOIN (SELECT patient_id, MAX(meet_date) as prev_date FROM Appointments  WHERE id!=@id GROUP BY patient_id) as am ON am.patient_id=a.patient_id 
LEFT JOIN (SELECT patient_id, bill_balance FROM Billing WHERE id IN (SELECT MAX(id) FROM Appointments WHERE bill_status=2 OR bill_status=3 AND bill_type=2 GROUP BY patient_id)) as b ON b.patient_id=a.patient_id  
WHERE a.id=@id;

END

GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_Get_History]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[uspConsultationDet_Get_History] @id int , @patient_id int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT a.id,a.meet_date, dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name,a.notes , aps.name as status_name
FROM Appointments a JOIN Doctors d ON d.id=a.doctor_id 
LEFT JOIN Appointment_Status aps ON a.status=aps.id WHERE /*a.id!=@id AND */a.patient_id=@patient_id ORDER BY meet_date DESC;

END
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_Procedures_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Create new procedures/tests
-- =============================================
CREATE PROCEDURE [dbo].[uspConsultationDet_Procedures_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	SELECT pp.id, p.name, p.description, t.type_name,pp.notes, pp.fee, pp.status, st.name as status_name from Patient_Procedures pp LEFT JOIN  Procedures p ON p.id=pp.procedure_id LEFT JOIN Procedure_Types t ON t.id=p.type 
	 LEFT JOIN Procedure_Status st ON st.id=pp.status WHERE pp.appointment_id = @id
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_Procedures_Single]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspConsultationDet_Procedures_Single] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	SELECT pp.id, p.name, p.description, t.type_name,pp.notes, pp.fee, pp.status,t.id as type_id,pp.procedure_id from Patient_Procedures pp LEFT JOIN  Procedures p ON p.id=pp.procedure_id LEFT JOIN Procedure_Types t ON t.id=p.type 
	WHERE pp.id = @id
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspConsultationDet_SaveDiagnosis]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspConsultationDet_SaveDiagnosis] @appointment_id int,@patient_id int, @history text,  @allergies text, @notes text
	AS	
	Declare @Ret int;
	Set @Ret = -1;	
		Begin
			Update Patients Set [history] = @history, [allergies]=@allergies WHERE [id]=@patient_id 
			Update Appointments set [notes]=@notes, [status]=2 WHERE id=@appointment_id
			set @Ret = 1;
		End
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspDepartments_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspDepartments_Add] @name Varchar(max),  @description text, @active bit As
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Departments Where name = @name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into Departments (name,description, active)
		Values (@name,@description, @active);
	set @Ret = 1;
	End
	select @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspDepartments_Combo]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDepartments_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT id, name from Departments WHERE Active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY active, name';

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspDepartments_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[uspDepartments_Edit] @id int, @name Varchar(max),  @desc text, @active bit
	AS	
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Departments Where name = @name and id <> @id)
		Begin
			Set @Ret = 0;		
		End
	Else
		Begin
			Update Departments Set [name] = @name, [description]=@desc, active=@active WHERE [id]=@id 
			set @Ret = 1;
		End
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspDepartments_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[uspDepartments_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select id, name, description, active from Departments';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
exec(@sql);
end

GO
/****** Object:  StoredProcedure [dbo].[uspDoctors_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[uspDoctors_Add]  @first_name varchar(50),  @last_name varchar(50) = NULL, @department_id int,
@designation varchar(50), @qualification varchar(max) = NULL, @specialization varchar(max) =NULL, @address varchar(max) = NULL,
@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(50)=NULL, @legal_id varchar(50),
@legal_id_expiry date=NULL, @nationality varchar(50),@gender char(1), @dob date, @consultation_fee decimal(10,3),
@active bit, @added_id int As
	SET NOCOUNT ON;
	Declare @user_id as int;
	Declare @Ret int;
	Set @Ret = -1;
	
	Declare @emp_id int;
	select @emp_id =  (MAX(id) + 1) From Users;
	if(@emp_id IS NULL)
		set @emp_id = 1

	Declare @prefix varchar(10);
	Select @prefix = op_value FROM Options WHERE op_name = 'EMPID_PREFIX'; 

	Declare @start int;
	Select   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'EMPID_START'; 

	Set @emp_id = @emp_id+@start;
	Set @prefix = @prefix + cast(@emp_id as varchar)
	
	DECLARE @password VARBINARY(MAX);
	SELECT @password = CAST(op_value AS VARBINARY(MAX)) FROM Options WHERE op_name = 'DEFAULT_PWD'; 

	DECLARE @salt VARBINARY(4) = CRYPT_GEN_RANDOM(4);
	DECLARE @hash VARBINARY(MAX); 
	SET @hash = 0x0200 + @salt + HASHBYTES('SHA2_512',@password + @salt);

	Insert Into Users (emp_id,password,[salt],user_type_id,active,log_date)
		Values (@prefix,@hash,@salt, 3,@active,GETDATE());


	select @user_id = SCOPE_IDENTITY();

	insert into Doctors (first_name, last_name, department_id,designation, qualification, specialization, address,
city, state, zip, phone, email, legal_id,legal_id_expiry, nationality,gender,dob, consultation_fee,user_id,
active, added_date,modified_date,added_id,modified_id) values (@first_name,  @last_name, @department_id,
@designation, @qualification, @specialization, @address,
@city, @state, @zip, @phone, @email , @legal_id, @legal_id_expiry, @nationality,@gender, @dob, @consultation_fee,@user_id,
@active, GETDATE(), getdate(),@added_id ,1);

Set @Ret =1;

Select @Ret;

GO
/****** Object:  StoredProcedure [dbo].[uspDoctors_Combo]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE PROCEDURE [dbo].[uspDoctors_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql varchar(max);
	
	SET @sql = 'SELECT id , dbo.svf_FormatDrName(first_name,last_name) as name from Doctors WHERE Active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY active, first_name, last_name';

	EXEC(@sql);
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspDoctors_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Edit Doctors
-- =============================================
CREATE PROCEDURE [dbo].[uspDoctors_Edit] @id int, @user_id int,  @first_name varchar(50),  @last_name varchar(50) = NULL, @department_id int,
@designation varchar(50), @qualification varchar(max) = NULL, @specialization varchar(max) =NULL, @address varchar(max) = NULL,
@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(50)=NULL, @legal_id varchar(50),
@legal_id_expiry date=NULL, @nationality varchar(50),@gender char(1), @dob date, @consultation_fee decimal(10,3),
@active bit, @modified_id int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
		BEGIN
			UPDATE dbo.[Users] SET active=@active WHERE [ID]=@user_id
			UPDATE dbo.[Doctors] SET [first_name] = @first_name, [last_name]=@last_name, department_id=@department_id, designation=@designation, qualification=@qualification,
			specialization=@specialization, address=@address, city=@city,state=@state, zip=@zip, phone=@phone,email=@email,
			legal_id=@legal_id,legal_id_expiry=@legal_id_expiry,nationality=@nationality, gender=@gender, dob=@dob, consultation_fee=@consultation_fee, modified_id=@modified_id, modified_date=getdate(), active=@active WHERE [id]=@id 
			SET @Ret = 1;
		END
SELECT @Ret
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspDoctors_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[uspDoctors_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select D.id as id, U.emp_id,dbo.svf_FormatDrName(D.first_name,D.last_name) as name, De.name as department,
D.designation, D.phone, D.gender, D.legal_id as pathaka, D.consultation_fee, D.active from Doctors D JOIN Users U ON U.id=D.user_id
JOIN Departments De ON De.id=D.department_id';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
set @sql = @sql + ' order by D.first_name';
exec(@sql);
end
GO
/****** Object:  StoredProcedure [dbo].[uspDoctors_GetSingle]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDoctors_GetSingle] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT d.*, dt.name,U.emp_id FROM dbo.[Doctors] d JOIN dbo.Departments dt ON dt.id=d.department_id 
	JOIN USERS U ON U.id=d.user_id WHERE d.id=@id
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspMenus_GetActive]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspMenus_GetActive] @active bit 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT * FROM dbo.Menu_Items WHERE active=@active ORDER BY parent_id, menu_order, menu_text;

	 
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspMenuUserTypes_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspMenuUserTypes_Add]
  @List AS dbo.MenuList READONLY, @utype int
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM dbo.Menu_User_Types WHERE user_type_id=@utype;
  INSERT INTO dbo.Menu_User_Types SELECT id, @utype FROM @List; 
END
GO
/****** Object:  StoredProcedure [dbo].[uspMenuUserTypes_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMenuUserTypes_Get] @utype int 
AS

BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON; 
 
 SELECT * FROM dbo.Menu_User_Types m WHERE user_type_id=@utype;

  
 
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspMenuUserTypes_GetDetailed]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspMenuUserTypes_GetDetailed] @utype int 
AS

BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON; 
 
 SELECT mu.*, m.* FROM dbo.Menu_User_Types mu  JOIN dbo.Menu_Items m ON mu.menu_id=m.id
 WHERE mu.user_type_id=@utype AND m.active=1 ORDER BY m.parent_id, m.menu_order, m.menu_text;

  END
GO
/****** Object:  StoredProcedure [dbo].[uspMenuUserTypes_GetRemoveList]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[uspMenuUserTypes_GetRemoveList] @utype int 
AS

BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON; 
 
 SELECT s1.* FROM  (SELECT m.* FROM dbo.Menu_User_Types mu  JOIN dbo.Menu_Items m ON mu.menu_id=m.id
 WHERE mu.user_type_id=1 AND m.active=1) s1 
 LEFT JOIN 
 (
 SELECT m.* FROM dbo.Menu_User_Types mu  JOIN dbo.Menu_Items m ON mu.menu_id=m.id
 WHERE mu.user_type_id=@utype AND m.active=1) s2 ON s1.id=s2.id WHERE s2.id IS NULL;

  
 
END
GO
/****** Object:  StoredProcedure [dbo].[uspOptions_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspOptions_Add] @name Varchar(max), @description text, @val Varchar(max) AS
	DECLARE @Ret int; 
	SET @Ret = -1;
	
	IF Exists (SELECT 1 From dbo.[Options] WHERE op_name = @name)
	BEGIN
		SET @Ret = 0;
		return;
	END

	ELSE
	BEGIN
	INSERT INTO dbo.[Options] (op_name, op_description, op_value)
		Values (@name, @description, @val);
	SET @Ret = 1;
	End
	SELECT @Ret;
 
GO
/****** Object:  StoredProcedure [dbo].[uspOptions_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspOptions_Edit] @id int, @name Varchar(max),  @desc text, @val Varchar(max)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
	IF Exists (SELECT 1 FROM dbo.[Options] WHERE [op_name] = @name and id <> @id)
		BEGIN
			SET @Ret = 0;		
		END
	ELSE
		BEGIN
			UPDATE dbo.[Options] SET op_name = @name, op_description=@desc, op_value=@val WHERE [id]=@id 
			SET @Ret = 1;
		END
SELECT @Ret
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspOptions_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspOptions_Get] @SearchBy varchar(50), @SearchValue varchar(100) AS
BEGIN
DECLARE @sql nvarchar(max);
SET @sql = 'SELECT id, op_name, op_description, op_value FROM Options';

IF(@SearchBy <> 'All')
BEGIN
SET @sql = @sql + ' WHERE ' + @SearchBy + ' LIKE ''' + @SearchValue + '%''';
END
EXEC(@sql);
END


 
GO
/****** Object:  StoredProcedure [dbo].[uspOptions_Many]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspOptions_Many] @name varchar(100) AS
BEGIN
SELECT op_name, op_value FROM dbo.[Options] WHERE op_name IN (@name) 
END
 
CREATE TABLE dbo.Menu_Items
	(
	id int NOT NULL IDENTITY (1, 1),
	parent_id int NOT NULL,
	menu_name varchar(50) NOT NULL,
	menu_text varchar(50) NULL,
	active bit NOT NULL,
		locked bit NOT NULL	)  ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspOptions_Single]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspOptions_Single] @name varchar(100) AS
BEGIN
SELECT * FROM dbo.[Options] WHERE op_name=@name 
END
GO
/****** Object:  StoredProcedure [dbo].[uspPatients_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPatients_Add]  @first_name varchar(50),  @last_name varchar(50) = NULL, @gender char(1), @dob date, @nationality varchar(50),@legal_id varchar(50)= NULL,
@legal_id_expiry date=NULL, @address varchar(max) = NULL,@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(100)=NULL,   @history text=NULL, @allergies text=NULL, 
@loggedid int AS
	SET NOCOUNT ON;
	DECLARE @id AS int;
	DECLARE @patid AS int;	
	DECLARE @Ret int;
	SET @Ret = -1;
	
	DECLARE @prefix varchar(20);
	DECLARE @patnum varchar(20);
	
	SELECT @patid=(ISNULL(MAX(id),0)+ 1) From Patients;
	SELECT @prefix = op_value FROM Options WHERE op_name = 'PATIENTID_PREFIX'; 
	
	DECLARE @start int;
	SELECT   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'PATIENTID_START'; 
	
	SET @patid = @patid+@start;
	SET @patnum = @prefix + cast(@patid as varchar);
	
	
	

	INSERT INTO dbo.Patients(patient_number,first_name, last_name, nationality,gender,dob, legal_id,legal_id_expiry, address,
city, state, zip, phone, email,history,allergies,active, added_date,modified_date,added_id,modified_id) 
	VALUES (@patnum, @first_name,  @last_name, @nationality,@gender, @dob, @legal_id, @legal_id_expiry, @address,
@city, @state, @zip, @phone, @email ,  @history, @allergies,1, GETDATE(), GETDATE(),@loggedid , @loggedid);

	SELECT @id = SCOPE_IDENTITY();
	SET @patid = @id+@start;
	SET @patnum = @prefix + cast(@patid as varchar);
	UPDATE dbo.Patients SET patient_number=@patnum WHERE id=@id;
	SET @Ret = @id;
	
SELECT @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspPatients_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Edit Patients
-- =============================================
CREATE PROCEDURE [dbo].[uspPatients_Edit] @id int, @first_name nchar(10),  @last_name varchar(max) = NULL,  @gender char(1), @dob date, @nationality varchar(50), 
@legal_id varchar(50),@legal_id_expiry date=NULL,@address varchar(max) = NULL,
@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(50)=NULL, 
@history text, @allergies text, @loggedid int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
		BEGIN
			
			UPDATE dbo.[Patients] SET [first_name] = @first_name, [last_name]=@last_name, address=@address, city=@city,state=@state, zip=@zip, phone=@phone,email=@email,
			legal_id=@legal_id,nationality=@nationality, gender=@gender, dob=@dob, history=@history, modified_id=@loggedid, modified_date=getdate(), allergies=@allergies WHERE [id]=@id 
			SET @Ret = @@ROWCOUNT;
		END
SELECT @Ret
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspPatients_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[uspPatients_Get] @SearchBy varchar(50), @SearchValue varchar(100) AS
BEGIN
DECLARE @sql nvarchar(max);
SET @sql = 'SELECT id, patient_number, dbo.svf_FormatName(first_name,last_name) as name, 
gender, dbo.svf_GetAge(dob) AS age , dbo.svf_FormatAddress(address,city,state,zip) as address1, phone FROM Patients';

IF(@SearchBy <> 'All')
BEGIN
SET @sql = @sql + ' WHERE ' + @SearchBy + ' LIKE ''' + @SearchValue + '%'' ORDER BY patient_number';
END
EXEC(@sql);
END

GO
/****** Object:  StoredProcedure [dbo].[uspPatients_GetDetailed]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPatients_GetDetailed] @id int, @aid int AS
BEGIN

DECLARE @visit_date Datetime;
SET @visit_date = NULL;

DECLARE @app_id int;
SET @app_id = 0;

DECLARE @doctor_id int;
SET @doctor_id = 0;

DECLARE @doctor_name VARCHAR(50);
SET @doctor_name = NULL;

DECLARE @dues decimal(10,3)
SET @dues = 0;

DECLARE @doc_fee decimal(10,3)
SET @doc_fee = 0;

DECLARE @token int
SET @token = 0;


IF(@aid > 0)
 BEGIN
 SET @app_id = @aid;
 SELECT TOP 1 @dues=isnull(bill_balance,0) FROM Billing WHERE appointment_id!=@aid AND bill_type=2 AND patient_id=@id ORDER BY id DESC 
 END
ELSE
 BEGIN
 SELECT @app_id = MAX(id) FROM Appointments WHERE patient_id=@id AND [Status] IN (2,4) GROUP BY patient_id; 
 SELECT TOP 1 @dues=isnull(bill_balance,0) FROM Billing WHERE appointment_id=@app_id AND bill_type=2 AND patient_id=@id ORDER BY id DESC 
 END
IF(@app_id > 0)
 BEGIN
 SELECT @visit_date=a.meet_date, @doctor_id=d.id, @doctor_name=CONCAT(d.first_name,' ',d.last_name), @doc_fee=d.consultation_fee, @token=a.token FROM Appointments a JOIN Doctors d ON a.doctor_id=d.id WHERE a.id=@aid;
 END
SELECT *, CONCAT(first_name, ' ', last_name) as patient_name, DATEDIFF(YEAR, dob,GETDATE()) as age,
@visit_date as meet_date, @app_id as appointment_id, @doctor_id as doctor_id,@doctor_name as doctor_name, @doc_fee as doctor_fee, @dues as dues, @token as token 
 FROM Patients WHERE id=@id ;
END
GO
/****** Object:  StoredProcedure [dbo].[uspPatients_GetSingle]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspPatients_GetSingle] @id int AS
BEGIN
SELECT * FROM Patients WHERE id=@id;
END 
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Create new procedures/tests
-- =============================================
CREATE PROCEDURE [dbo].[uspProcedures_Add] @name Varchar(max),  @desc text, @type int, @fee decimal(10,2), @active bit
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From dbo.Procedures Where name = @name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into dbo.Procedures(name,description,type,fee, active)
		Values (@name,@desc,@type,@fee, @active);
	set @Ret = 1;
	End
	select @Ret
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_ALL]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspProcedures_ALL]  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	/*, t.type_name --  JOIN dbo.Procedure_Types t ON t.id=p.type WHERE p.id=@id*/
	SELECT p.* FROM dbo.[PROCEDURES] p ORDER BY name
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_Combo]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Datatable for Procedure Types Combobox
-- =============================================
CREATE PROCEDURE [dbo].[uspProcedures_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT id, name from Procedures WHERE Active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY Active, name';

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Create new procedures/tests
-- =============================================
CREATE PROCEDURE [dbo].[uspProcedures_Edit] @id int, @name Varchar(max),  @desc text, @type int, @fee decimal(10,2), @active bit
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
	IF Exists (SELECT 1 FROM dbo.[Procedures] WHERE [name] = @name and id <> @id)
		BEGIN
			SET @Ret = 0;		
		END
	ELSE
		BEGIN
			UPDATE dbo.[Procedures] SET [name] = @name, [description]=@desc, type=@type, fee=@fee, active=@active WHERE [id]=@id 
			SET @Ret = 1;
		END
SELECT @Ret
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Create new procedures/tests
-- =============================================
CREATE PROCEDURE [dbo].[uspProcedures_Get] @SearchBy varchar(50), @SearchValue varchar(100) 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT p.id, p.name, p.description, p.type, t.type_name, p.fee, p.active from Procedures p JOIN Procedure_Types t ON t.id=p.type ';
	
	IF(@SearchBy <> 'All')
	BEGIN
	SET @sql = @sql + ' WHERE ' + @SearchBy + ' like ''' + @SearchValue + '%''';
	END

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_GetFee]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspProcedures_GetFee] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	DECLARE @fee as decimal(10,2)	
	SELECT @fee = fee FROM dbo.[PROCEDURES]  WHERE id=@id
	SELECT @fee
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspProcedures_Single]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspProcedures_Single] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT p.*, t.type_name FROM dbo.[PROCEDURES] p JOIN dbo.Procedure_Types t ON t.id=p.type WHERE p.id=@id
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspProcedureStatus_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspProcedureStatus_Get] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT id, name from Procedure_Status WHERE Active = 1 ';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY Active, name';

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedureTypes_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspProcedureTypes_Add] @type_name Varchar(max), @description text, @active bit AS
	Declare @Ret int; 
	Set @Ret = -1;
	If Exists (Select 1 From Procedure_Types Where type_name = @type_name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into Procedure_Types (type_name, description, active)
		Values (@type_name, @description, @active);
	set @Ret = 1;
	End
	Select @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspProcedureTypes_Combo]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Insync Tech Solutions
-- Create date: 2017-12-01
-- Description:	Datatable for Procedure Types Combobox
-- =============================================
CREATE PROCEDURE [dbo].[uspProcedureTypes_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT id, type_name from Procedure_Types WHERE Active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY Active, type_name';

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspProcedureTypes_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspProcedureTypes_Edit] @id int, @name Varchar(max),  @desc text, @active bit
	AS	
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Procedure_Types Where type_name = @name and id <> @id)
		Begin
			Set @Ret = 0;		
		End
	Else
		Begin
			Update Procedure_Types Set [type_name] = @name, [description]=@desc, active=@active WHERE [id]=@id 
			set @Ret = 1;
		End
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspProcedureTypes_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspProcedureTypes_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select id, type_name, description,active from Procedure_Types';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
exec(@sql);
end

GO
/****** Object:  StoredProcedure [dbo].[uspReport_Billing]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspReport_Billing]  @fromDate DateTime = '', @toDate DateTime ='', @bill_type int = 0,
@bill_status int =0  AS
BEGIN
SELECT CONVERT(date, b.bill_date) as appt_date, b.bill_number, b.bill_amount, dbo.svf_FormatName(p.first_name, p.last_name) as patient_name, 
dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name, bs.name as status, bt.name as type, b.bill_paid,  b.bill_balance 
FROM Billing b JOIN Bill_Status bs ON bs.id=b.bill_status JOIN Bill_Types bt ON bt.id=b.bill_type
LEFT JOIN Appointments a ON a.id=b.appointment_id 
LEFT JOIN Doctors d ON d.id=a.doctor_id LEFT JOIN Patients p ON  p.id=a.patient_id WHERE 
CONVERT(date,b.bill_date)>=@fromDate AND CONVERT(date,b.bill_date)<=@toDate  
AND b.bill_type = case when @bill_type>0  then @bill_type else b.bill_type END 
AND b.bill_status = case when @bill_status>0  then @bill_status else b.bill_status END 
ORDER BY b.bill_date DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_Medical]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspReport_Medical] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT a.*, dbo.svf_FormatDrName(d.first_name, d.last_name) as doctor_name,  p.id as patient_id ,p.patient_number , dbo.svf_FormatName(p.first_name, p.last_name) as patient_name
,p.gender, p.nationality, p.phone, p.dob, p.address, p.city, p.state, p.zip, dbo.svf_GetAge(p.dob) as age, p.history, p.allergies, CONVERT(date, am.start_date) as start_date, CAST(a.meet_date AS DATE)  as appointment_date, ast.name as status_name, ast.edit_lock as status_edit_lock 
FROM Appointments a 
JOIN Patients p ON a.patient_id=p.id 
JOIN Doctors d ON d.id=a.doctor_id 
JOIN Appointment_Status ast ON a.status = ast.id
/*LEFT JOIN Patient_Procedures pp ON pp.patient_id=  p.id 
LEFT JOIN Procedure_Types pt ON pt.id=pp.procedure_id*/
LEFT JOIN (SELECT patient_id, MIN(meet_date) as start_date FROM Appointments  GROUP BY patient_id) as am ON am.patient_id=a.patient_id 

WHERE a.id=@id;

END

GO
/****** Object:  StoredProcedure [dbo].[uspReport_Patient]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspReport_Patient]  @fromDate DateTime = '', @toDate DateTime ='', @SearchBy varchar(50), @SearchValue varchar(100) AS
BEGIN
DECLARE @sql nvarchar(max);
set @sql = '';
IF(@SearchBy <> 'All')
BEGIN
SET @sql = ' AND ' + @SearchBy + ' LIKE ''' + @SearchValue + '%'' ';
END

if @SearchBy<>'ALL' BEGIN
SELECT CONVERT(date, a.meet_date) as appt_date, a.notes, dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name, p.patient_number, dbo.svf_FormatName(p.first_name,p.last_name) as name, 
p.gender, dbo.svf_GetAge(p.dob) AS age , dbo.svf_FormatAddress(p.address,p.city,p.state,p.zip) as address1, 
p.phone FROM Appointments a JOIN Patients p ON a.patient_id=p.id JOIN Doctors d ON a.doctor_id=d.id WHERE
CONVERT(date,a.meet_date)>=@fromDate AND CONVERT(date,a.meet_date)<=@toDate AND
(CASE @SearchBy
        WHEN 'first_name' THEN p.first_name 
		WHEN  'last_name' THEN p.last_name 
		WHEN 'phone_number' THEN p.phone
		WHEN 'patient_number' THEN p.patient_number
 END)

LIKE @SearchValue+'%'	

ORDER BY p.patient_number;
end
else
BEGIN
SELECT CONVERT(date, a.meet_date) as appt_date, a.notes, dbo.svf_FormatDrName(d.first_name,d.last_name) as doctor_name, p.patient_number, dbo.svf_FormatName(p.first_name,p.last_name) as name, 
p.gender, dbo.svf_GetAge(p.dob) AS age , dbo.svf_FormatAddress(p.address,p.city,p.state,p.zip) as address1, 
p.phone FROM Appointments a JOIN Patients p ON a.patient_id=p.id JOIN Doctors d ON a.doctor_id=d.id WHERE
CONVERT(date,a.meet_date)>=@fromDate AND CONVERT(date,a.meet_date)<=@toDate 
ORDER BY p.patient_number;
end



END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_Patient_SQL]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspReport_Patient_SQL]  @fromDate DateTime = '', @toDate DateTime ='', @SearchBy varchar(50), @SearchValue varchar(100) AS
BEGIN
DECLARE @sql nvarchar(max);
set @sql = '';
IF(@SearchBy <> 'All')
BEGIN
SET @sql = ' AND ' + @SearchBy + ' LIKE ''' + @SearchValue + '%'' ';
END
print @SearchBy
if @SearchBy<>'ALL' BEGIN
SELECT a.meet_date, a.notes, p.id, p.patient_number, dbo.svf_FormatName(p.first_name,p.last_name) as name, 
p.gender, dbo.svf_GetAge(p.dob) AS age , dbo.svf_FormatAddress(p.address,p.city,p.state,p.zip) as address1, 
p.phone FROM Appointments a JOIN Patients p ON a.patient_id=p.id JOIN Doctors d ON a.doctor_id=d.id WHERE
CONVERT(date,a.meet_date)>=@fromDate AND CONVERT(date,a.meet_date)<=@toDate AND
(CASE @SearchBy
        WHEN 'first_name' THEN p.first_name 
		WHEN  'last_name' THEN p.last_name 
 END)

LIKE @SearchValue+'%'	

ORDER BY p.patient_number;
end
else
BEGIN
SELECT a.meet_date, a.notes, p.id, p.patient_number, dbo.svf_FormatName(p.first_name,p.last_name) as name, 
p.gender, dbo.svf_GetAge(p.dob) AS age , dbo.svf_FormatAddress(p.address,p.city,p.state,p.zip) as address1, 
p.phone FROM Appointments a JOIN Patients p ON a.patient_id=p.id JOIN Doctors d ON a.doctor_id=d.id WHERE
CONVERT(date,a.meet_date)>=@fromDate AND CONVERT(date,a.meet_date)<=@toDate 
ORDER BY p.patient_number;
end



END
GO
/****** Object:  StoredProcedure [dbo].[uspStaffs_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspStaffs_Add]  @first_name nchar(10),  @last_name varchar(max) = NULL, @department_id int,
@designation varchar(50), @qualification varchar(max) = NULL, @staff_type_id int, @address varchar(max) = NULL,
@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(50)=NULL, @legal_id varchar(50),
@legal_id_expiry date=NULL, @nationality nchar(10),@gender char(1), @dob date,
@active bit, @added_id int As
	SET NOCOUNT ON;
	Declare @user_id as int;
	Declare @Ret int;
	Set @Ret = -1;
	
	Declare @emp_id int;
	select @emp_id =  (MAX(id) + 1) From Users;
	if(@emp_id IS NULL)
		set @emp_id = 1

	Declare @prefix varchar(10);
	Select @prefix = op_value FROM Options WHERE op_name = 'EMPID_PREFIX'; 

	Declare @start int;
	Select   @start = TRY_CAST (op_value AS INT) FROM Options WHERE op_name= 'EMPID_START'; 

	Set @emp_id = @emp_id+@start;
	Set @prefix = @prefix + cast(@emp_id as varchar)
	
	DECLARE @password VARBINARY(MAX);
	SELECT @password = CAST(op_value AS VARBINARY(MAX)) FROM Options WHERE op_name = 'DEFAULT_PWD'; 

	DECLARE @salt VARBINARY(4) = CRYPT_GEN_RANDOM(4);
	DECLARE @hash VARBINARY(MAX); 
	SET @hash = 0x0200 + @salt + HASHBYTES('SHA2_512',@password + @salt);

	Insert Into Users (emp_id,password,[salt],user_type_id,active,log_date)
		Values (@prefix,@hash,@salt, 4,@active,GETDATE());


	select @user_id = SCOPE_IDENTITY();

	insert into Staffs (first_name, last_name, department_id,designation, qualification, staff_type_id, address,
city, state, zip, phone, email, legal_id,legal_id_expiry, nationality,gender,dob, user_id,
active, added_date,modified_date,added_id,modified_id) values (@first_name,  @last_name, @department_id,
@designation, @qualification, @staff_type_id, @address,
@city, @state, @zip, @phone, @email , @legal_id, @legal_id_expiry, @nationality,@gender, @dob, @user_id,
@active, GETDATE(), getdate(),@added_id ,@added_id);

Set @Ret =1;
SELECT @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspStaffs_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspStaffs_Edit] @id int, @user_id int,  @first_name varchar(50),  @last_name varchar(50) = NULL, @department_id int,
@designation varchar(50), @qualification varchar(max) = NULL, @staff_type_id int, @address varchar(max) = NULL,
@city varchar(max)=NULL, @state varchar(max) = NULL, @zip varchar(50)=NULL, @phone varchar(50), @email varchar(50)=NULL, @legal_id varchar(50),
@legal_id_expiry date=NULL, @nationality varchar(50),@gender char(1), @dob date, 
@active bit, @modified_id int
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DECLARE @Ret int;
	SET @Ret = -1;
		BEGIN
			UPDATE dbo.[Users] SET active=@active WHERE [ID]=@user_id
			UPDATE dbo.[Staffs] SET [first_name] = @first_name, [last_name]=@last_name, department_id=@department_id, designation=@designation, qualification=@qualification,
			staff_type_id=@staff_type_id, address=@address, city=@city,state=@state, zip=@zip, phone=@phone,email=@email,
			legal_id=@legal_id,legal_id_expiry=@legal_id_expiry,nationality=@nationality, gender=@gender, dob=@dob,modified_id=@modified_id, modified_date=getdate(), active=@active WHERE [id]=@id 
			SET @Ret = 1;
		END
SELECT @Ret
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspStaffs_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE procedure [dbo].[uspStaffs_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select D.id as id, U.emp_id,CONCAT( D.first_name,D.last_name) as name, De.name as department,
D.designation, D.phone, D.gender, D.legal_id as pathaka, D.active, ST.type_title from Staffs D JOIN Users U ON U.id=D.user_id
JOIN Departments De ON De.id=D.department_id JOIN Staff_Types ST ON ST.id=D.staff_type_id ';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
set @sql = @sql + ' order by D.first_name';
exec(@sql);
end

GO
/****** Object:  StoredProcedure [dbo].[uspStaffs_GetSingle]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspStaffs_GetSingle] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	SELECT d.*, dt.name,U.emp_id ,st.type_title FROM dbo.[Staffs] d JOIN dbo.Departments dt ON dt.id=d.department_id 
	JOIN USERS U ON U.id=d.user_id JOIN Staff_Types st ON st.id=d.staff_type_id WHERE d.id=@id
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspStaffType_Combo]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspStaffType_Combo] @id int 
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(max);
	
	SET @sql = 'SELECT id, type_title from Staff_Types WHERE active = 1';
	
	IF(@id > 0)
	BEGIN
	SET @sql = @sql + ' OR  id=''' +   CAST(@id AS varchar(30)) + '''';
	END

	SET @sql = @sql + ' ORDER BY active, type_title';

	EXEC(@sql);
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspStaffTypes_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspStaffTypes_Add] @type_title Varchar(50), @description text, @active bit AS
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Staff_Types Where type_title = @type_title)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into Staff_Types (type_title, type_description, active)
		Values (@type_title, @description, @active);
	set @Ret = 1;
	End
	Select @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspStaffTypes_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspStaffTypes_Edit] @id int, @name Varchar(max),  @desc text, @active bit
	AS	
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From Staff_Types Where type_title = @name and id <> @id)
		Begin
			Set @Ret = 0;		
		End
	Else
		Begin
			Update Staff_Types Set [type_title] = @name, [type_description]=@desc, active=@active WHERE [id]=@id 
			set @Ret = 1;
		End
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspStaffTypes_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspStaffTypes_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select id, type_title, type_description,active from Staff_Types';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
exec(@sql);
end

GO
/****** Object:  StoredProcedure [dbo].[uspUsers_GetDetails]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsers_GetDetails] @id int  
AS

BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON; 
 

 SELECT u.*, t.type_name,s.staff_id, s.staff_name, s.staff_phone FROM dbo.Users u JOIN dbo.User_Types t ON u.user_type_id=t.id 
 LEFT JOIN 
 (SELECT d.id as staff_id, d.user_id as staff_user_id, CONCAT(d.first_name, ' ', d.last_name) as staff_name, d.phone as staff_phone FROM dbo.Users u JOIN dbo.Doctors d ON u.id=d.user_id WHERE u.id=@id
 UNION 
 SELECT d.id as staff_id, d.user_id as staff_user_id, CONCAT(d.first_name, ' ', d.last_name) as staff_name, d.phone as staff_phone FROM dbo.Users u JOIN dbo.Staffs d ON u.id=d.user_id WHERE u.id=@id) 
 s ON u.id=s.staff_user_id 
 WHERE u.id=@id;
 END
GO
/****** Object:  StoredProcedure [dbo].[uspUsers_LoggedUser]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUsers_LoggedUser] @empid varchar(20)  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	

	SELECT u.*, t.type_name, s.* FROM dbo.Users u JOIN dbo.User_Types t ON u.user_type_id=t.id 
	LEFT JOIN 
	(SELECT d.id as staff_id, d.user_id as staff_user_id, dbo.svf_FormatDrName(d.first_name, d.last_name) as staff_name, d.phone as staff_phone, 'Doctors' as staff_tbl, 'Doctor' as staff_type, d.nationality, d.gender, d.dob, dbo.svf_GetAge(d.dob) as age, d.designation, dp.name as department FROM dbo.Users u JOIN dbo.Doctors d ON u.id=d.user_id JOIN dbo.Departments dp ON dp.id=d.department_id WHERE u.emp_id=@empid 
	UNION 
	SELECT d.id as staff_id, d.user_id as staff_user_id, dbo.svf_FormatName(d.first_name, d.last_name) as staff_name, d.phone as staff_phone, 'Staffs' as staff_tbl,st.type_title as staff_type,d.nationality, d.gender, d.dob, dbo.svf_GetAge(d.dob) as age, d.designation, dp.name as department FROM dbo.Users u JOIN dbo.Staffs d ON u.id=d.user_id JOIN dbo.Departments dp ON dp.id=d.department_id JOIN  dbo.Staff_Types st ON d.staff_type_id=st.id  WHERE u.emp_id=@empid) 
	s ON u.id=s.staff_user_id 
	WHERE u.emp_id=@empid;

	 
	
END

GO
/****** Object:  StoredProcedure [dbo].[uspUsers_SetLogDate]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[uspUsers_SetLogDate] @empid varchar(20)  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	DECLARE @Ret int;
	SET @Ret = 0;
	UPDATE dbo.Users SET log_date=GETDATE() WHERE emp_id=@empid;
	SET @Ret = 1; 

	SELECT @Ret;

	 
	
END
 
GO
/****** Object:  StoredProcedure [dbo].[uspUsers_SetPwdHash]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsers_SetPwdHash] @empid varchar(20), @pass  varchar(50), @utype int  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 DECLARE @salt1 VARBINARY(4) = CRYPT_GEN_RANDOM(4);	 
	 DECLARE @hash1 VARBINARY(MAX);
	 DECLARE @id VARCHAR(20);
	 SET @hash1 = 0x0200 + @salt1 + HASHBYTES('SHA2_512', CAST(@pass AS VARBINARY(MAX)) + @salt1);
	 SELECT @id=emp_id FROM dbo.Users WHERE emp_id=@empid;
	 if(@id != '')
	 BEGIN
		UPDATE dbo.Users  SET password=@hash1,salt=@salt1 WHERE emp_id=@empid;
	 END
	 ELSE
	 BEGIN
		INSERT INTO dbo.Users (emp_id,password,salt,user_type_id,active) VALUES(@empid,@hash1,@salt1,@utype,1);
	 END

	
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsers_ValidateLogin]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsers_ValidateLogin] @empid varchar(20), @pass  varchar(50)  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 DECLARE @salt1 VARBINARY(4);	 
	 DECLARE @hash VARBINARY(MAX); 
	 DECLARE @hash1 VARBINARY(MAX);
	 DECLARE @Ret int;
	 SET @Ret = 0;

	 SELECT @salt1=salt,@hash1=[password] FROM dbo.Users WHERE emp_id=@empid AND active=1;
	 if(@salt1 <> '' AND @hash1 <> '')
	 BEGIN
		SET @hash = 0x0200 + @salt1 + HASHBYTES('SHA2_512', CAST(@pass AS VARBINARY(MAX)) + @salt1);
		IF(@hash = @hash1)
		BEGIN
			SET @Ret = 1; ;
		END
		ELSE
		BEGIN
			SET @Ret = -1;
		END	
	 END
	 SELECT @Ret;
	
END
GO
/****** Object:  StoredProcedure [dbo].[uspUserTypes_Add]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[uspUserTypes_Add] @type_name Varchar(max), @description text, @active bit AS
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From User_Types Where type_name = @type_name)
	Begin
		Set @Ret = 0;
		return;
	End
	Else
	Begin
	Insert Into User_Types (type_name, description, active)
		Values (@type_name, @description, @active);
	set @Ret = 1;
	End
	Select @Ret;
GO
/****** Object:  StoredProcedure [dbo].[uspUserTypes_Edit]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUserTypes_Edit] @id int, @name Varchar(50),  @desc text, @active bit
	AS	
	Declare @Ret int;
	Set @Ret = -1;
	If Exists (Select 1 From User_Types Where type_name = @name and id <> @id)
		Begin
			Set @Ret = 0;		
		End
	Else
		Begin
			Update User_Types Set [type_name] = @name, [description]=@desc, active=@active WHERE [id]=@id 
			set @Ret = 1;
		End
SELECT @Ret
GO
/****** Object:  StoredProcedure [dbo].[uspUserTypes_Get]    Script Date: 13-03-2018 10:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspUserTypes_Get] @SearchBy varchar(50), @SearchValue varchar(100) as
begin
declare @sql nvarchar(max);
set @sql = 'select id, type_name, description,active from User_Types';
if(@SearchBy <> 'All')
begin
set @sql = @sql + ' where ' + @SearchBy + ' like ''' + @SearchValue + '%''';
end
exec(@sql);
end

GO
