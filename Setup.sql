-- -- MSSQL BAD : MYSQL GOOD
-- -- STRICTLY-TYPED COMMANDS  <-- Right-Click: Run MySQL Query

-- -- NOTE WILL RUN EVERY COMMAND THAT IS TYPED OUT!!!

-- SECTION CREATING TABLES
-- NOTE If one of your collections references a parent for its values, the PARENT must be created before the CHILD


-- CREATE TABLE lords(
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     age INT,
--     imgUrl VARCHAR(255),

--     PRIMARY KEY (id)
-- );


/* 
CREATE TABLE kingdoms(
    id INT NOT NULL AUTO_INCREMENT,
    lordId VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    garrison INT,
    imgUrl VARCHAR(255),

    PRIMARY KEY (id)
    FOREIGN KEY (lordId)
        REFERENCES lords (id)
        ON DELETE CASCADE
);
 */

/* 
CREATE TABLE knights(
    id INT NOT NULL AUTO_INCREMENT,
    kingdomId VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    age INT,
    imgUrl VARCHAR(255),

    PRIMARY KEY (id)
    FOREIGN KEY (kingdomId)
        REFERENCES kingdoms (id)
        ON DELETE CASCADE
);
 */ 

-- -- SECTION ADD DATA TO TABLE

-- INSERT INTO lords
--  (name, age, imgUrl)
--  VALUES
--  ("The Pale King", 100, "https://i.redd.it/1987lkukqii41.jpg") 

-- INSERT INTO kingdoms
--  (name, garrison, imgUrl)
--  VALUES
--  ("Hallownest", 0, "https://i.redd.it/dl0wd31f9dr51.jpg") 

-- INSERT INTO knights
--  (name, age, imgUrl)
--  VALUES
--  ("The Hollow Knight", 5, "https://pbs.twimg.com/media/EBGc3vBWkAEiNTg.jpg") 


-- -- SECTION ADD COLUMN TO TABLE
-- ALTER TABLE knights
-- ADD COLUMN kingdomId VARCHAR(255) AFTER id;

-- -- SECTION GET DATA FROM TABLE
-- -- SELECT {columns} FROM {table} WHERE {query}

-- -- GET ALL
-- SELECT * FROM lords
-- SELECT * FROM kingdoms
-- SELECT * FROM knights

-- -- GET BY ID
-- Select * FROM knights WHERE birthyear > 1960



-- -- SECTION EDIT DATA IN TABLE

-- UPDATE knights
-- SET kingdomId = 5
-- WHERE id = 5




-- -- SECTION DELETE DATA FROM TABLE
-- DELETE FROM lords WHERE id = 3
-- DELETE FROM kingdoms WHERE id = 3
-- DELETE FROM knights WHERE id = 3

-- -- FIXME !!!DANGER ZONE!!!

-- -- REMOVE ALL DATA FROM TABLE
-- DELETE FROM lords
-- DELETE FROM kingdoms
-- DELETE FROM knights


-- -- DELETE ENTIRE TABLE
-- DROP TABLE lords
-- DROP TABLE kingdoms
-- DROP TABLE knights

-- -- DELETE ENTIRE DATABASE
-- DROP DATABASE