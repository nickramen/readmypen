cadena1 = "Hola soy Nicole y mi nombre es Nicole"
cadena2 = "3"
cadena3 = "alfanumerico"

# print (dir(cadena1))

mayusc = cadena1.upper()
minus = cadena1.lower()
primer_letra_mayusc = cadena1.capitalize()
busqueda_find = cadena1.find("a")
#busqueda_index = cadena1.index("d")
es_numerico = cadena2.isnumeric()
es_alfanumerico = cadena3.isalpha()
contar_coincidencias = cadena1.count("Nicole")
contar_caracteres = len(cadena1)
empieza_con = cadena1.startswith("H")

print(empieza_con)
