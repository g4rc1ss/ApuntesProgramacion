def impar(n):
    if n%2 != 0:
        return True
    else:
        return False

if __name__ == '__main__':
    import doctest, os
    doctest.testfile("fmatemat2.txt")