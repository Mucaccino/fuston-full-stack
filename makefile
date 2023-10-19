.PHONY: build run stop clean

build:
	docker-compose build

run:
	docker-compose up

stop:
	docker-compose down

clean:
	docker-compose down --rmi all --volumes --remove-orphans
