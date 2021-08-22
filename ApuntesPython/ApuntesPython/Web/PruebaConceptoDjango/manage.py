#!/usr/bin/env python
"""Django's command-line utility for administrative tasks."""
import os
import sys
import subprocess
import platform


def main():
    """Run administrative tasks."""
    os.environ.setdefault('DJANGO_SETTINGS_MODULE', '_01_Frontend._Config.settings')
    try:
        from django.core.management import execute_from_command_line
    except ImportError                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     as exc:
        raise ImportError(
            "Couldn't import Django. Are you sure it's installed and "
            "available on your PYTHONPATH environment variable? Did you "
            "forget to activate a virtual environment?"
        ) from exc
    execute_from_command_line(sys.argv)

def createDatabase():
    if os.environ['PROCESSOR_ARCHITECTURE'].endswith('64'):
        if platform.system() == "Windows":
            subprocess.call("..\\InicializarBBDD_PostgreSQL\\winx64\\PruebaConceptoMigrations_PostgreSQL.exe")
        elif platform.system() == "Darwin":
            subprocess.call("..\\InicializarBBDD_PostgreSQL\\MacOSx64\\PruebaConceptoMigrations_PostgreSQL")
        elif platform.system() == "Linux":
            subprocess.call("..\\InicializarBBDD_PostgreSQL\\Linux_x64\\PruebaConceptoMigrations_PostgreSQL")
    pass

if __name__ == '__main__':
    createDatabase()
    main()
