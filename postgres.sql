--
-- PostgreSQL database dump
--

-- Dumped from database version 12.2
-- Dumped by pg_dump version 12.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


--
-- Name: delete_order(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.delete_order(_order_id integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
begin
	delete from tbl_orders where order_id = _order_id;
	if found then
		return 1;
	else
		return 0;
	end if;
end;
$$;


ALTER FUNCTION public.delete_order(_order_id integer) OWNER TO postgres;

--
-- Name: get_unit_price(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_unit_price(p_id integer) RETURNS numeric
    LANGUAGE plpgsql
    AS $$
declare
	unit_price decimal;
begin
	select unitprice
	into unit_price
	from public.tbl_products
	where public.tbl_products.product_id = p_id;
	
	return unit_price;
end;
$$;


ALTER FUNCTION public.get_unit_price(p_id integer) OWNER TO postgres;

--
-- Name: insert_order(integer, integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.insert_order(_user_id integer, _product_id integer, _pieces integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
begin
	insert into public.tbl_orders
	(
		user_id,
		product_id,
		pieces,
		unitprice		
	)values
	(
		_user_id,
		_product_id,
		_pieces,
		get_unit_price(_product_id)	
	);
	if found then
		return 1;
	else
		return 0;
	end if;
end;
$$;


ALTER FUNCTION public.insert_order(_user_id integer, _product_id integer, _pieces integer) OWNER TO postgres;

--
-- Name: select_order(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.select_order() RETURNS TABLE(_order_id integer, _user_id integer, _product_id integer, _pieces integer, _unitprice numeric)
    LANGUAGE plpgsql
    AS $$
begin
	return query
	select order_id,user_id,product_id,pieces,unitprice from tbl_orders;
end;
$$;


ALTER FUNCTION public.select_order() OWNER TO postgres;

--
-- Name: select_products(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.select_products() RETURNS TABLE(_product_id integer, _p_name character varying, _unitprice numeric)
    LANGUAGE plpgsql
    AS $$
begin
	return query
	select product_id,p_name,unitprice from tbl_products;
end;
$$;


ALTER FUNCTION public.select_products() OWNER TO postgres;

--
-- Name: select_users(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.select_users() RETURNS TABLE(_user_id integer, _u_name character varying, _u_lastname character varying, _birthdate date, _address character varying)
    LANGUAGE plpgsql
    AS $$
begin
	return query
	select user_id,u_name,u_lastname,birthdate,address from tbl_user;
end;
$$;


ALTER FUNCTION public.select_users() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: tbl_orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_orders (
    order_id integer NOT NULL,
    user_id integer NOT NULL,
    product_id integer NOT NULL,
    pieces integer,
    unitprice numeric(10,2)
);


ALTER TABLE public.tbl_orders OWNER TO postgres;

--
-- Name: tbl_orders_order_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_orders_order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tbl_orders_order_id_seq OWNER TO postgres;

--
-- Name: tbl_orders_order_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_orders_order_id_seq OWNED BY public.tbl_orders.order_id;


--
-- Name: tbl_orders_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_orders_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tbl_orders_product_id_seq OWNER TO postgres;

--
-- Name: tbl_orders_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_orders_product_id_seq OWNED BY public.tbl_orders.product_id;


--
-- Name: tbl_orders_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_orders_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tbl_orders_user_id_seq OWNER TO postgres;

--
-- Name: tbl_orders_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_orders_user_id_seq OWNED BY public.tbl_orders.user_id;


--
-- Name: tbl_products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_products (
    product_id integer NOT NULL,
    p_name character varying(75) NOT NULL,
    unitprice numeric(10,2)
);


ALTER TABLE public.tbl_products OWNER TO postgres;

--
-- Name: tbl_products_product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_products_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tbl_products_product_id_seq OWNER TO postgres;

--
-- Name: tbl_products_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_products_product_id_seq OWNED BY public.tbl_products.product_id;


--
-- Name: tbl_user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tbl_user (
    user_id integer NOT NULL,
    u_name character varying(75) NOT NULL,
    u_lastname character varying(75) NOT NULL,
    birthdate date,
    address character varying(500)
);


ALTER TABLE public.tbl_user OWNER TO postgres;

--
-- Name: tbl_user_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tbl_user_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tbl_user_user_id_seq OWNER TO postgres;

--
-- Name: tbl_user_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tbl_user_user_id_seq OWNED BY public.tbl_user.user_id;


--
-- Name: tbl_orders order_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders ALTER COLUMN order_id SET DEFAULT nextval('public.tbl_orders_order_id_seq'::regclass);


--
-- Name: tbl_orders user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders ALTER COLUMN user_id SET DEFAULT nextval('public.tbl_orders_user_id_seq'::regclass);


--
-- Name: tbl_orders product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders ALTER COLUMN product_id SET DEFAULT nextval('public.tbl_orders_product_id_seq'::regclass);


--
-- Name: tbl_products product_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_products ALTER COLUMN product_id SET DEFAULT nextval('public.tbl_products_product_id_seq'::regclass);


--
-- Name: tbl_user user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user ALTER COLUMN user_id SET DEFAULT nextval('public.tbl_user_user_id_seq'::regclass);


--
-- Data for Name: tbl_orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_orders (order_id, user_id, product_id, pieces, unitprice) FROM stdin;
5	1	4	3	9.50
7	2	2	2	60.45
8	2	1	4	8.00
9	3	2	1	60.45
11	3	4	5	9.50
\.


--
-- Data for Name: tbl_products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_products (product_id, p_name, unitprice) FROM stdin;
1	ABC USB	8.00
2	DE kulaklık	60.45
3	lenovo mouse	8.00
4	Def USB	9.50
\.


--
-- Data for Name: tbl_user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tbl_user (user_id, u_name, u_lastname, birthdate, address) FROM stdin;
1	Ali	Alıç	1998-06-06	Çankaya/ANKARA
2	Osman	Beylik	1970-05-11	Kuleli Sok.
3	Elif	Işık	1995-11-23	Kırkkonaklar Mah.
4	Hazal	K.R.	1998-06-06	316.Cad 334.Sok.
5	Türkan	G.	1998-06-06	İncek
\.


--
-- Name: tbl_orders_order_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_orders_order_id_seq', 11, true);


--
-- Name: tbl_orders_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_orders_product_id_seq', 1, false);


--
-- Name: tbl_orders_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_orders_user_id_seq', 1, false);


--
-- Name: tbl_products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_products_product_id_seq', 4, true);


--
-- Name: tbl_user_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_user_user_id_seq', 5, true);


--
-- Name: tbl_orders tbl_orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders
    ADD CONSTRAINT tbl_orders_pkey PRIMARY KEY (order_id);


--
-- Name: tbl_products tbl_products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_products
    ADD CONSTRAINT tbl_products_pkey PRIMARY KEY (product_id);


--
-- Name: tbl_user tbl_user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_user
    ADD CONSTRAINT tbl_user_pkey PRIMARY KEY (user_id);


--
-- Name: tbl_orders tbl_orders_product_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders
    ADD CONSTRAINT tbl_orders_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.tbl_products(product_id);


--
-- Name: tbl_orders tbl_orders_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tbl_orders
    ADD CONSTRAINT tbl_orders_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.tbl_user(user_id);


--
-- PostgreSQL database dump complete
--

