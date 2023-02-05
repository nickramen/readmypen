diccionarios = {
    "nombre": "nicole",
    "apellido": "ramos",
    "edad": 22
}

claves = diccionarios.keys()
get_value = diccionarios.get("nombre")
diccionarios.pop("edad")
#diccionarios.clear()
dic_iterable = diccionarios.items()

print(dic_iterable)