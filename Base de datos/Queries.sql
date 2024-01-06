#Queries System Project Tasks

#CREATE DATABASE system_project_tasks;

USE system_project_tasks;

SELECT * FROM project;
SELECT * FROM user;
SELECT * FROM task;
SELECT * FROM project_user;

#PROJECT TABLE#
/*CREATE TABLE project(
	id_project INT AUTO_INCREMENT,
    nameP VARCHAR(50) NOT NULL,
    descriptionP VARCHAR(100) NULL,
    statusP BOOLEAN DEFAULT FALSE,
    PRIMARY KEY(id_project)
);*/

#INSERT INTO project(nameP,descriptionP,statusP) VALUES ('Proyecto C#','Descripción del proyecto c#',true);

#USER TABLE#
/*CREATE TABLE user(
	id_user INT AUTO_INCREMENT,
    nameU VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    PRIMARY KEY(id_user)
);*/

#INSERT INTO user(nameU,last_name) VALUES ('Karol', 'Morales');

#TASK TABLE#
/*CREATE TABLE task(
	id_task INT AUTO_INCREMENT,
    nameT VARCHAR(50) NOT NULL,
    descriptionT VARCHAR(100) NULL,
    priority INT DEFAULT 0,
    statusP INT DEFAULT 0,
    due_date DATE DEFAULT (CURRENT_DATE()),
    PRIMARY KEY(id_task),
    id_project_fk INT,
    id_user_fx INT,
    FOREIGN KEY(id_project_fk) REFERENCES project(id_project)
    ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(id_user_fx) REFERENCES user(id_user)
    ON DELETE CASCADE ON UPDATE CASCADE
);*/

INSERT INTO task(nameT,descriptionT,id_project_fk,id_user_fx) VALUES ('Tarea 8', 'Crear servicio',76,5);

#PROJECT_USER TABLE#
/*CREATE TABLE project_user(
	id_project_user INT AUTO_INCREMENT,
    id_project_fk INT,
    id_user_fx INT,
    PRIMARY KEY(id_project_user),
    FOREIGN KEY(id_project_fk) REFERENCES project(id_project)
    ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY(id_user_fx) REFERENCES user(id_user)
    ON DELETE CASCADE ON UPDATE CASCADE
);*/

INSERT INTO project_user(id_project_fk,id_user_fx) VALUES (63,9);

#Obtener las tareas de X proyecto#
SELECT t.nameT AS Nombre, t.descriptionT AS Descripción
FROM project p
INNER JOIN task t ON p.id_project = t.id_project_fk
WHERE p.id_project = 4;

#Obtener todas las tareas de X usuario#
SELECT t.nameT AS tarea, t.descriptionT AS descripción
FROM  user u
INNER JOIN task t ON u.id_user = t.id_user_fx
WHERE u.id_user = 4;

#Obtener todas las tareas de X usuario en X Proyecto#
SELECT t.nameT AS tarea, t.descriptionT AS descripción
FROM  user u 
INNER JOIN task t ON u.id_user = t.id_user_fx
INNER JOIN project p ON t.id_project_fk = p.id_project
WHERE u.id_user = 1 AND p.id_project = 5;

#Obtener todos los usuarios de X proyecto#
SELECT u.id_user AS Codigo, u.nameU AS Nombre, u.last_name AS Apellido
FROM user u
INNER JOIN project_user pu ON u.id_user = pu.id_user_fx
INNER JOIN project p ON p.id_project = pu.id_project_fk
WHERE p.id_project = 39;