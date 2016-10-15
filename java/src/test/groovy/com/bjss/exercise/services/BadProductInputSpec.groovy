package com.bjss.exercise.services

import com.bjss.exercise.domain.Product
import com.bjss.exercise.persistence.ProductRepository
import spock.lang.Specification

class BadProductInputSpec extends Specification {

    def "Not valid items should not be served"() {
        given:
        def repository = [findByNames: {
            String[] names -> names.collect { s -> new Product() {{ setName(s)}} }
        }] as ProductRepository

        def service = new BasketService(repository)
        when:
        def basket = service.get(["Milk"] as String[])
        then:
        def excluded = basket.findNotPresent([ invalid ] as String[])
        assert excluded.contains(invalid)
        where:
        invalid | _
        "aaaa"  | _
    }
}
