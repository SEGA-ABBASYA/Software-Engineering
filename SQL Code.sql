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
    user_id NUMBER NOT NULL,
    event_id NUMBER NOT NULL,
    CONSTRAINT pk_participants PRIMARY KEY (user_id, event_id),
    CONSTRAINT fk_participant_user FOREIGN KEY (user_id) REFERENCES users_table(id),
    CONSTRAINT fk_participant_event FOREIGN KEY (event_id) REFERENCES events_table(id)
);

-- USERS SEQUENCE AND TRIGGER
CREATE SEQUENCE users_seq
START WITH 1
INCREMENT BY 1
NOCACHE;

CREATE OR REPLACE TRIGGER trg_users_auto_id
BEFORE INSERT ON users
FOR EACH ROW
BEGIN
  IF :NEW.id IS NULL THEN
    :NEW.id := users_seq.NEXTVAL;
  END IF;
END;


-- EVENTS SEQUENCE AND TRIGGER
CREATE SEQUENCE events_seq
START WITH 1
INCREMENT BY 1
NOCACHE;

CREATE OR REPLACE TRIGGER trg_events_auto_id
BEFORE INSERT ON events
FOR EACH ROW
BEGIN
  IF :NEW.id IS NULL THEN
    :NEW.id := events_seq.NEXTVAL;
  END IF;
END;


insert into users_table values
(1, 'Ziad', 'ziadshraf100@gmail.com', 1000);
insert into users_table values
(2, 'Zoz', 'ziadshraf123@gmail.com', 1000);

insert into events_table values
(1, 'Employment Fair', 'Abbasyia', '4-Oct-2025', 'upcoming', 2, 100 );
insert into events_table values
(2, 'Swift', 'Zamalek', '29-Apr-2025', 'ended', 1, 0 );
insert into events_table values
(3, 'Google Dev Fest', 'Greek Campus', '29-Apr-2026', 'ended', 3, 0 );
insert into events_table values
(4, 'TechShift', 'Greek Campus', '25-Jan-2026', 'ended', 1, 0 );


insert into participants_table values
( 1, 1);
insert into participants_table values
( 2, 2);

commit

create or replace procedure GetID (UID out number)
as
begin
select max(id)
into UID
from users_table;
end;