lista = ["Nicole", "nickramen", True, 22] # se pueden modificar
tupla = ["Nicole", "nickramen", True, 22] # no se pueden modificar

lista[3] = "A toda maquina"
print(lista)

conjunto = {"Nicole", "nickramen", True, 22} # no se accede a tados por indice, y no guarda datos duplicados, no tienen un orden fijo, no se puede modificar

# print(conjunto[3]) # no puede mostrar el indice

# key : value / se separa con comas
diccionario = {
    'nombre' : 'nicole',
    'apellido' : 'ramos',
    'edad' : 22
}

print(diccionario['edad'] + 3)