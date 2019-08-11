# Amazing Search
It's a dotnet Core 2.1 application that workds with Elasticsearch 6.3.1 (+Kibana) for education purposes.


## Instructions to Test the Application ##

### 1 - Create a "docker-compose.yml" with the content below: ###
```
version: '3'
services:
  elasticsearch:
    image: docker.elastic.co/elasticsearch/elasticsearch:6.3.1
    container_name: elasticsearch
    environment:
      - node.name=elastic_node01
      - discovery.type=single-node
    ports:
      - 9200:9200
  kibana:
    image: docker.elastic.co/kibana/kibana:6.3.1
    ports:
      - 5601:5601
  amazingsearchwebapp:
    image: gustavomg/amazing-search:1.0
    ports:
      - 8080:80
```
<https://hub.docker.com/r/gustavomg/amazing-search>


### 2 - Go to "http://localhost:8080" in your browser. ###
The Amazing Search website will be presented.




### 3 - Click the "Seed" link at the top of the page. ###
The Elasticsearch will be filled with some pages.



### 4 - Go back to "Home" (link at the top of the page) and do some searches like: ###
* brasil
* esporte




### 5 - Use Kibana to explore Elasticsearch data. ###
After a search, the "user_activity_log_index" will be created in Elasticsearch filled with user activities.
You can explore the index of Web Pages and the User Activity index.



