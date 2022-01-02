# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey has `on_delete` set to the desired behavior.
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Directores(models.Model):
    id = models.TextField(db_column='Id', primary_key=True)  # Field name made lowercase.
    nombre = models.TextField(db_column='Nombre', blank=True, null=True)  # Field name made lowercase.
    apellidos = models.TextField(db_column='Apellidos', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Directores'


class Peliculas(models.Model):
    id = models.TextField(db_column='Id', primary_key=True)  # Field name made lowercase.
    titulo = models.TextField(db_column='Titulo', blank=True, null=True)  # Field name made lowercase.
    duracion = models.DecimalField(db_column='Duracion', max_digits=20, decimal_places=2)  # Field name made lowercase.
    pais = models.TextField(db_column='Pais', blank=True, null=True)  # Field name made lowercase.
    genero = models.TextField(db_column='Genero', blank=True, null=True)  # Field name made lowercase.
    directorid = models.ForeignKey(Directores, models.DO_NOTHING, db_column='DirectorId', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Peliculas'
