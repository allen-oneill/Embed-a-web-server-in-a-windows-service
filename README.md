# Embed a web server in a windows service

Sample code for article:

Embed a web server in a windows service

Published at: http://www.codeproject.com/Articles/694907/Embed-a-web-server-in-a-windows-service

Introduction

A Windows service is a long running process that sits in the background, executing when needed. Services don't interact with the desktop, and this raises many issues, including the problem of controlling the service to a finer level than simply clicking "start service" "stop service" in the services control panel. This article describes using the NancyFX framework to provide a web browser interface to your Windows service, giving you much more control on what's going on and managing the internals for the service itself.
