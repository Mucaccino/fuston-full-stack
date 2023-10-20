.PHONY: build run stop clean
LIBDIR = src
SPADIR = spa

build:
	docker-compose build

run:
	docker-compose up

stop:
	docker-compose down

clean:
	docker-compose down --rmi all --volumes --remove-orphans

db-update:
	cd ./src/cliente && dotnet ef database update
	cd ./src/contas && dotnet ef database update
	cd ./src/transacao && dotnet ef database update

spa-setup:
	make -C $(SPADIR) install

spa-dev:
	make -C $(SPADIR) dev

spa-build:
	make -C $(SPADIR) build