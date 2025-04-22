FROM mcr.microsoft.com/windows/servercore:ltsc2019

WORKDIR /app

COPY pom.xml ./

RUN ./mvnw dependency:resolve

COPY src ./src

RUN ["mvn", "clean", "install"]

CMD ["java", "-jar", "target/app.jar"]

