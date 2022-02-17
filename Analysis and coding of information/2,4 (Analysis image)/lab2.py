import struct
import cv2
import copy


def read_header(file_name):
    with open(file_name, 'rb') as file:
        print('Type:', file.read(2).decode())
        print('Size: %s' % struct.unpack('I', file.read(4)))
        print('Reserved 1: %s' % struct.unpack('H', file.read(2)))
        print('Reserved 2: %s' % struct.unpack('H', file.read(2)))
        print('Offset: %s' % struct.unpack('I', file.read(4)))
        print('DIB Header Size: %s' % struct.unpack('I', file.read(4)))
        print('Width: %s' % struct.unpack('I', file.read(4)))
        print('Height: %s' % struct.unpack('I', file.read(4)))
        print('Colour Planes: %s' % struct.unpack('H', file.read(2)))
        print('Bits per Pixel: %s' % struct.unpack('H', file.read(2)))
        print('Compression Method: %s' % struct.unpack('I', file.read(4)))
        print('Raw Image Size: %s' % struct.unpack('I', file.read(4)))
        print('Horizontal Resolution: %s' % struct.unpack('I', file.read(4)))
        print('Vertical Resolution: %s' % struct.unpack('I', file.read(4)))
        print('Number of Colours: %s' % struct.unpack('I', file.read(4)))
        print('Important Colours: %s' % struct.unpack('I', file.read(4)))


def image_decomposition(photo):
    colors = ["green", "red", "blue"]
    for i in range(3):
        img = copy.copy(photo)
        for j in img:
            for k in j:
                k[i] = 0
                k[i-1] = 0

        cv2.imshow(colors[i], img)


def bitmap(photo, byte_number):
    img = copy.copy(photo)
    for i in img:
        for j in i:
            for n in range(3):
                zero = "00000000"
                zero = "{0:08b}".format(j[n])[:byte_number] + zero[byte_number:]
                j[n] = int(zero, base=2)
    cv2.imshow("bitmap " + str(byte_number), img)


if __name__ == "__main__":
    filename = '3.bmp'
    image = cv2.imread(filename, cv2.IMREAD_COLOR)

    # Чтение хэдера
    read_header(filename)

    # Разложение на цвета
    image_decomposition(image)

    filename = '1.bmp'
    image = cv2.imread(filename, cv2.IMREAD_COLOR)
    # Битовые срезы
    for bit in range(8):
        bitmap(image, bit)

    cv2.waitKey(0)
