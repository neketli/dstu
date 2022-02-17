import cv2
import numpy as np


def create_blank(width, height):
    image = np.zeros((height, width, 3), np.uint8)
    return image


def bump_picture_in_picture(photo_name, photo_for_code_name, bit_count):
    photo = cv2.imread(photo_name, cv2.IMREAD_COLOR)
    photo_for_code = cv2.imread(photo_for_code_name, cv2.IMREAD_COLOR)
    x, y = len(photo_for_code[0]),  len(photo_for_code)

    for i, p in zip(photo_for_code, photo):
        for j, p1 in zip(i, p):
            for n in range(3):
                binary_string = "{0:08b}".format(p1[n])
                binary_string = binary_string[:bit_count] + "{0:08b}".format(j[n])[
                                                                  : - bit_count]
                p1[n] = int(binary_string, base=2)

    cv2.imshow("Sewn-in image " + str(bit_count), photo)
    take_from_picture(photo, 6, x, y)



def take_from_picture(photo_for_dec, bit_count, x, y):
    image = create_blank(x, y)

    for i, p in zip(image, photo_for_dec):
        for j, p1 in zip(i, p):
            for n in range(3):
                binary_string = "{0:08b}".format(p1[n])
                binary_string = binary_string[bit_count:] + "{0:08b}".format(j[n])[
                                                                  - bit_count:]
                j[n] = int(binary_string, base=2)

    cv2.imshow("Seized image", image)


if __name__ == "__main__":
    source_file = '1.bmp'
    receive_file = '2.bmp'

    bump_picture_in_picture(source_file, receive_file, 6)

    cv2.waitKey(0)
