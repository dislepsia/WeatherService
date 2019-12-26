# Que es?
Es el servicio de consulta del pronostico del tiempo del challenge de MeLi

# Uso
Nos dirigimos a http://weatherapimeli.azurewebsites.net/api/weather para obtener el pronostico hasta diez años desde el dia de la fecha 
o bien http://weatherapimeli.azurewebsites.net/api/weather/n donde n es un entero entre [1;3650] y que retorna el clima del dia 
especificado por parámetro

# Decisiones tomadas
Se publicó en Azure ya que poseo una cuenta con las credenciales dado al convenio con Microsoft que posee mi actual trabajo. 
Generalmente no suelo realizar la publicación en esta plataforma porque utilizamos IIS.
