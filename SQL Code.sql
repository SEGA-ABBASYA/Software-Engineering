-- USERS TABLE
CREATE TABLE users_table (
    id NUMBER PRIMARY KEY,
    username VARCHAR2(255) NOT NULL,
    email VARCHAR2(255) UNIQUE NOT NULL,
    balance_fees NUMBER(10,2) DEFAULT 0 CHECK (balance_fees >= 0)
);

-- EVENTS TABLE
CREATE TABLE events_table (
    id NUMBER PRIMARY KEY,
    name VARCHAR2(255) NOT NULL,
    location VARCHAR2(255),
    event_date DATE NOT NULL,
    status VARCHAR2(20) CHECK (status IN ('upcoming', 'ended', 'overdue', 'canceled')),
    priority NUMBER CHECK (priority IN (1, 2, 3)),
    fees NUMBER(10,2) DEFAULT 0 CHECK (fees >= 0)
);

-- PARTICIPANTS TABLE
CREATE TABLE participants_table (
    user_id NUMBER,
    event_id NUMBER,
    CONSTRAINT fk_participants_user
        FOREIGN KEY (user_id)
        REFERENCES users_table(id)
        ON DELETE CASCADE,
    CONSTRAINT fk_participants_event
        FOREIGN KEY (event_id)
        REFERENCES events_table(id)
        ON DELETE CASCADE,
    CONSTRAINT pk_participants PRIMARY KEY (user_id, event_id)
);

-- EVENTS SEQUENCE
CREATE SEQUENCE events_seq
START WITH 4
INCREMENT BY 1
NOCACHE;


--- Procedures

-- Get User Details Using Out Parameters
CREATE OR REPLACE PROCEDURE GET_USER_BALANCE(
    p_user_name  IN  VARCHAR2,
    p_balance    OUT Number,
    p_user_id    OUT Number
) AS
BEGIN
    SELECT balance_fees, id
      INTO p_balance, p_user_id
      FROM users_table
     WHERE UPPER(username) = UPPER(p_user_name);
END GET_USER_BALANCE;
/

-- Get Users Max Id Using Only 1 Out Number Parameter
create or replace procedure GetID (UID out number)
as
begin
select max(id)
into UID
from users_table;
end;
/

-- Selects Multiple Rows Using SysRefCursor
CREATE OR REPLACE PROCEDURE get_events_participants(
    result_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN result_cursor FOR
        SELECT 
            e.name AS event_name,
            u.email AS user_email
        FROM 
            participants_table p
        JOIN 
            events_table e ON p.event_id = e.id
        JOIN 
            users_table u ON p.user_id = u.id
        WHERE 
            TRUNC(e.event_date) = TRUNC(SYSDATE + 1);
END;
/


-- Insertions

-- Users Insertions
insert into users_table values
(1, 'Ziad', 'ziadkhaled@gmail.com', 1000);
insert into users_table values
(2, 'Mustafa', 'must123@gmail.com', 1000);

-- Events Insertions
insert into events_table values
(1, 'Employment Fair', 'Abbasyia', '4-Oct-2025', 'upcoming', 2, 100 );
insert into events_table values
(2, 'Swift', 'Zamalek', '29-Apr-2025', 'ended', 1, 0 );
insert into events_table values
(3, 'Google Dev Fest', 'Greek Campus', '29-Apr-2026', 'upcoming', 3, 0 );

-- Particpants Insertions
insert into participants_table values
(1, 1);
insert into participants_table values
(2, 2);


-- Commit Updates
commit

