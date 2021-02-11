from pytube import YouTube
import os
'''
    Descargamos videos de youtube
'''
video = YouTube('https://www.youtube.com/watch?v=oztyvJYMx2s')

print(f'''{video.title}
------------------------------------------------
{video.description}
------------------------------------------------
{video.video_id}''')

for x in video.streams.all():
    print(x)

ruta=os.path.abspath(os.path.dirname(__file__))

video.streams.first().download(ruta)

'''
    Descargamos el video en .mp3
'''

video.streams.filter(only_audio=True).first().download(ruta)
