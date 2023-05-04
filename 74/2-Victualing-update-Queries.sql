update stock_items set item_id= '1ace0944-cdd1-4213-a292-e1ef6d37e18b' where item_id ='ed0a1e99-865b-4bb8-a4b3-6e289549b804' and stock_master_id in (select id from stock_master where vessel_id = 74);
update stock_items set item_id= 'e0db233a-74bb-4407-9712-e84d981cd89e' where item_id ='7e258342-2842-404f-8fd8-ef63b082b6e9' and stock_master_id in (select id from stock_master where vessel_id = 74);
