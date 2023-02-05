lista = list(["hola","nicole","ramos"])
lista1 = list([23,445,23,7,68,643,2])

cadena = "hola"
cantidad_elementos = len(lista)
lista.append("hola")
lista.insert(2,"como estas")
lista.extend([False,2023])
lista.pop(0) #elimina
lista.pop(-1) #elimina anteultimo
lista.remove("ramos")
lista1.sort() #ordena ascendente
lista1.sort(reverse=True) #ordena descendente
lista1.reverse()
lista.clear() #elimina todo

print(lista1)