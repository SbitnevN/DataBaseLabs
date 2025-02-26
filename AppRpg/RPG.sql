DROP TABLE IF EXISTS [user] 
CREATE TABLE [user](
	u_ID int identity,
	u_Name nvarchar(255),
	u_Email nvarchar(255),
	u_Pass nvarchar(255)
	constraint PK_ID primary key(u_ID)

)
DROP TABLE IF EXISTS [person]
CREATE TABLE [person](
	p_ID int identity,
	P_Name nvarchar(255),
	p_Nation nvarchar(255),
	p_Lvl int,
	p_Gender nvarchar(255),
	u_ID int
	primary key (p_ID),
	foreign key (u_ID) references [user] (u_ID)
)

DROP TABLE IF EXISTS [class]
CREATE TABLE [class](
	c_ID int identity,
	c_Name nvarchar(255),
	c_Effect nvarchar(255),
	c_Desc nvarchar(255)
	primary key (c_ID)
)

DROP TABLE IF EXISTS [location]
CREATE TABLE [location](
	l_ID int identity,
	l_Name nvarchar(255),
	l_Square int,
	l_Biome nvarchar(255),
	l_Lvl int
	primary key (l_ID)
)

DROP TABLE IF EXISTS [skill]
CREATE TABLE [skill](
	s_ID int identity,
	s_Name nvarchar(255),
	c_ID int,
	s_Effect nvarchar(255),
	s_Lvl int
	primary key (s_ID)
	foreign key (c_ID) references [class] (c_ID)
)

DROP TABLE IF EXISTS [npc]
CREATE TABLE [npc](
	n_ID int identity,
	n_Name nvarchar(255),
	n_Lvl int,
	l_ID int
	primary key (n_ID)
	foreign key (l_ID) references [location] (l_ID)
)
 
DROP TABLE IF EXISTS [item]
CREATE TABLE [item](
	i_ID int identity,
	i_Name nvarchar(255),
	i_Effect nvarchar(255),
	i_Lvl int,
	i_Type nvarchar(255)
	primary key(i_ID)
)


 
DROP TABLE IF EXISTS [mob]
CREATE TABLE [mob](
	m_ID int identity,
	m_Name nvarchar(255),
	m_Lvl int,
	m_Type nvarchar(255)
	primary key(m_ID)
)

DROP TABLE IF EXISTS [quest]
CREATE TABLE [quest](
	q_ID int identity,
	q_Name nvarchar(255),
	q_Lvl int,
	q_Reward nvarchar(255)
	primary key(q_ID)
)

DROP TABLE IF EXISTS [p_it]
CREATE TABLE [p_it](
	p_ID int not null,
	i_ID int not null,
	primary key (p_ID,i_ID),
	foreign key (p_ID) references [person](p_ID),
	foreign key (i_ID) references [item] (i_ID)
)

DROP TABLE IF EXISTS [p_class]
CREATE TABLE [p_class](
	p_ID int,
	c_ID int
	primary key (p_ID,c_ID),
	foreign key (p_ID) references [person] (p_ID),
	foreign key (C_ID) references [class] (C_ID)
)

DROP TABLE IF EXISTS [loc_m]
CREATE TABLE [loc_m](
	l_ID int not null,
	m_ID int not null
	primary key (l_ID,m_ID),
	foreign key (l_ID) references [location] (l_ID),
	foreign key (m_ID) references [mob] (m_ID)


)

DROP TABLE IF EXISTS [qu_np]
CREATE TABLE [qu_np](
	q_ID int,
	n_ID int
	primary key (q_ID,n_ID),
	foreign key (q_ID) references [quest] (q_ID),
	foreign key (n_ID) references [npc] (n_ID)
)

DROP TABLE IF EXISTS [qu_p]
CREATE TABLE [qu_p](
	q_ID int,
	p_ID int
	primary key (q_ID,p_ID),
	foreign key (q_ID) references [quest] (q_ID),
	foreign key (p_ID) references [person] (p_ID)
)

DROP TABLE IF EXISTS [loc_p]
CREATE TABLE [loc_p](
	p_ID int,
	l_ID int
	primary key (p_ID,l_ID),
	foreign key (p_ID) references [person] (p_ID),
	foreign key (l_ID) references [location] (l_ID)
)