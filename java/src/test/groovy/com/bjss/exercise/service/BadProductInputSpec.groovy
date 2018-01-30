package com.bjss.exercise.service

import com.bjss.exercise.domain.Product
import com.bjss.exercise.persistence.ProductRepository
import spock.lang.Specification

class BadProductInputSpec extends Specification {

    def 'Invalid items not served'() {
        given:
        def repository = [findByNames: { String[] names ->
            names.collect { s -> new Product(name: s) }
        }] as ProductRepository

        def service = new BasketService(repository)

        when:
        def basket = service.get(['Milk'] as String[])

        then:
        def excluded = basket.findAbsent([invalid] as String[])
        assert excluded.contains(invalid)

        where:
        invalid   | _
        "find me" | _
    }
}
