from google_drive_downloader import GoogleDriveDownloader as gd
import os

if not os.path.exists(os.path.abspath(os.path.dirname(__file__))+"/2ndHalfJava.zip"):
    gd.download_file_from_google_drive(
        file_id="0B7XV2PwnZyfNalJ6cFd6dXBrckE",
        dest_path=os.path.abspath(os.path.dirname(__file__))+"/2ndHalfJava.zip"
        )