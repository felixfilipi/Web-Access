SELECT * FROM BCAMIS01.WEB_ACCESS;

/
insert into BCAMIS01.WEB_ACCESS VALUES('RTGHR','U008644',	'Y',	'ACCESS', NULL,NULL,NULL,NULL);
/

create table temp_table_web_access (
RPT_CD varchar2(10),
NAMA_LAPORAN VARCHAR2(20)
);

INSERT INTO TEMP_TABLE_WEB_ACCESS VALUES('RPTDBKM', 'REPORT DBKM');

SELECT * FROM TEMP_TABLE_WEB_ACCESS;

CREATE TABLE TEMP_TABLE_USER_ACCESS (
USER_ID VARCHAR2(10),
NAMA_USER VARCHAR2(20)
);

INSERT INTO TEMP_TABLE_USER_ACCESS VALUES('U972782', 'TESTING NAME');
COMMIT;