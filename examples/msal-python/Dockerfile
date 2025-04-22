FROM mcr.microsoft.com/windows-cssc/python:3.11-servercore-ltsc2022

WORKDIR /app

COPY requirements.txt .

COPY . .

RUN python get-pip.py

RUN pip install --no-cache-dir -r requirements.txt



CMD [ "python", "./main.py" ]
