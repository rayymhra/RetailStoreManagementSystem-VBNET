-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 15, 2024 at 05:22 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sch_retailstore`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `adminId` int(11) NOT NULL,
  `fullName` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `address` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `telp` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `password` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`adminId`, `fullName`, `dateOfBirth`, `gender`, `address`, `telp`, `username`, `password`) VALUES
(1, 'olivia', '2024-05-30', 'Female', 'fortnite', '098765', 'adm1', '123');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_atm`
--

CREATE TABLE `tbl_atm` (
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `bankName` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `pin` int(50) NOT NULL,
  `balance` bigint(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_atm`
--

INSERT INTO `tbl_atm` (`username`, `bankName`, `pin`, `balance`) VALUES
('cust1', 'BCA', 123123, 164500);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_atmtransaction`
--

CREATE TABLE `tbl_atmtransaction` (
  `atmTrId` int(50) NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `date` date NOT NULL,
  `amount` bigint(150) NOT NULL,
  `type` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_atmtransaction`
--

INSERT INTO `tbl_atmtransaction` (`atmTrId`, `username`, `date`, `amount`, `type`) VALUES
(1, 'cust1', '2024-06-15', 5000, 'Withdraw'),
(2, 'cust1', '2024-06-15', 30000, 'Deposit');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_cashier`
--

CREATE TABLE `tbl_cashier` (
  `cashierId` int(50) NOT NULL,
  `fullName` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `dateOfBirth` date NOT NULL,
  `gender` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `address` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `telp` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `password` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_cashier`
--

INSERT INTO `tbl_cashier` (`cashierId`, `fullName`, `dateOfBirth`, `gender`, `address`, `telp`, `username`, `password`) VALUES
(1, 'maria', '2024-06-13', 'Female', 'sfafasdf', '3241234', 'cash1', '123'),
(2, 'hani', '2024-06-13', 'Male', 'sfsfs', '3425353', 'cash2', '234'),
(3, 'pollen', '2024-06-13', 'Male', 'california', '54363', 'cash3', '345');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_customer`
--

CREATE TABLE `tbl_customer` (
  `customerId` int(50) NOT NULL,
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `telp` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `loyaltyPoints` int(50) NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `password` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_customer`
--

INSERT INTO `tbl_customer` (`customerId`, `name`, `telp`, `loyaltyPoints`, `username`, `password`) VALUES
(1, 'proli', '0283477233', 0, 'cust1', '123'),
(2, 'lani', '245324442', 0, 'cust2', '234'),
(3, 'ida', '46434534523', 0, 'cust3', '345');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_events`
--

CREATE TABLE `tbl_events` (
  `eventId` int(50) NOT NULL,
  `details` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `poster` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_events`
--

INSERT INTO `tbl_events` (`eventId`, `details`, `startDate`, `endDate`, `poster`) VALUES
(3, 'free drinks', '2024-06-14', '2024-06-14', 0x89504e470d0a1a0a0000000d49484452000001bc000000530806000000e4d5b23c0000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa8640000149249444154785eed9ded6a5549d6c7bd262fa0612e2017e00d4c60a087077afa8be4933c825f463f1819866e060769244d1849d38cdd23e91e44114293312d84343179342463d4184ce2db4934f5acb5ea65afaa5dbbf639f12446f7ff343f3c67d7aeaa5555abd6bfaaf60e7d627777d7000000009f3a103c0000009d0082070000a01340f00000007402081e0000804e00c1030000d00920780000003a01040f0000402780e0010000e804103c0000009d0082070000a01340f00000007402081e0000804e00c1030000d00920780000003a01040f0000402738b1b4b464000000804f1decf00000007402081e0000804e00c1030000d00920780000003a01040f0000402780e0010000e804103c0000009d0082070000a01340f00000007402081e0000804e00c1030000d00920780000003a01040f000040273871f2f7770d000080e1900bb4e07800c103008021920bb4e07800c103008021920bb4e078a0046fcdccbc3466e3de8a3937ffd698973be6bc1ac461707e81caddda32a73369c3c5b565ee612dedca8a31e6d13333925c1f881bafa890d7e6da5826ed63e75369dbdfb6cc86796b66becda4758db16766994675e14626ad0b0ccba72777ccb6d933b7fe9649bbfdda9877afcc04f5f53ed5b6ff6e2f1b70c187a512bcb14db3ea02c4b535637a8b8fc2608e7cf5c4dc7af4d6f4ded148f2e7dd5bb3f1e09939e3f3f6c543736bcb98ed85b54c5a89fb667a83ea5c7b96496bc007bb49fa7ee139b5cb98e59b9cb66ee6de18b3facbfd7a9e01f87a895c7ae3b919cda41d37ae3d4afbfc91f4018b7e75cd2f10563eaab69518fda567cc9b17e6eb4cdaa173dcc456027ecf5c6f09f832f63b3be65c26adc8f72fa8746aef55fa3e68dba3f9f9c42c508c59be3d5fbfcf71101b87e5d3a7e7f61a3702b298e785f4d51d6acdbe79b7970fb86ddc1dffcc7cf69962fc90778c6b53e6cbcf2e9abbc9f5f5efbe3cfcba3f0095e0f1ea45069383dfbe999bb2d747e8fac6bb7db3b1f0d49cf9333be2bc199ddc34cb8f07dc018aa01ecd2a73c4adb6aea4694309440715ee0f432a78a3333dd3dba500a0046fe4270a88bbd45f631f57db4a0c65277f4046ee90d8e6fcef037174272befd9f6d20eeac00ccba7e7cdf5c7e4532b4f1ad344a839f6ecbf337b99605b66dd4cfd8904ee4f53665d5dbf3bfea5995ad3f70d99ae0a1eaf88c5295898fcca788c565cbbd659f281e3377369f6b5d9763bbfdec696391f5691f3e6dc1d95b643934e1d2b8c7c43a2c98b21feecf6cc749308e9d52905e489c5bdb0d3ecd1aa2d27ba12ec1e6f8acdfa7bb4ea1f7f6a167857b3f8c47c4ebffbb64756a4fb66797e87fac9debebdb8eefa27dd41c647abb2d2dc7c61a6d7b82fe843b65ca1ddf3cc065de70f05a5d09ea4addb0f9e8a9df572ca012212bc31b2ef25dd7f8f266510bc150908bcbb2bb78d1857b6d22e7fee866fa76df7c6d2f3d0873deaf3ec09c04daa9bfd405df30199ef3f35559561def4ccad49b7da77b6cd7deff2158fe95aec99a2451cf9b5fff4d69e49dff2c946d3cef7e4ef97cd95055a2cf8f1587a92dd31c82e407f6411599a2775b2be3846fe4af9f99183bd6f99c676dff4c8decf5d7bb7d75e8471ebad3c73f62501bfa1edd1a9c820e3a9cacfb73d97a722cc4f99e7fa9339828c6c8cfbd4ecd05cba90dccf789f5e7c11dabd71af12bf4b0bd51c33b4b05fbebd1cd2a27178f356eacaef3eb9bfacbdeccb073ace9cbd483bbabaf068f4eeefcbefd6c375112712ca2949ff1ff3bf7f8cd37777ef9a8b94e7e26c5556a04fc193df995da7afdb8b74fa3bdab1a6f765ca3b6c8a2fad9cb9470ecc02919d9cf33650b1a37d356f46bed2471334f0fc1c70f7b5b97ef9379aacf7cdc40a054abfcafc96567212301f52305d36d39b34a196d693f25d396a752adf5fbe3097ce9233fe79ddcc3c789e59b56a918905c7affa4f7d43b6d22e67f90ed74f7906b0c70af0be599d5d33a3d42fd247bc3be2b47407194d501b18cccb57e61af7c9654ea37a36766cfffdf8ca1e0b495e17cc1e3f37e7a8ada77c1a1f19f972b65e98092e47db96410bdee724f83d5aa1ca0ed80576d9ddf9312eb5ed02090cf5d9eaecaa3945637fe5018da73f269276d2cfc5a7e60c8f0d9749423cfd97ca8e00f7b51669ee07ea7b6e379f26847120c18f8eb2c5361504f542c897ede9db9e79737a9683b4ed5bed6b9c7e8603f80e07edfb2486d578d8b12221ca05d8c4e7dae6498d822f5e5aa43ea7b1ba44d72756de3ab1a33cd25e3e8579624e537ff038874545e3c2206e7b742a32c87846e5a76d6f43df5fda4159b48da3f29dc69ffaf4e4d915737d85fa37b95f703ebd716f9d7c7ade2e167342ccfe467d1d8e4bc54f3946ac88bf8ffe9bc7bcbfdd672ed0b621c25008fcb190c402e6c523081a8ba71297a298f62378517ebb13f5829a0a5cf43bb1e3ee77ea7a28af20c6874041f06c606d0cfc17f888b23afaf4cebb7c5ba57def57437a95795f1cbb7a46681d3d5f8fce67cbe7d5204fc2fabd0e2d32fa7b5805bf32dbbbe4b8535e2c06b1a7fe3cc006333b49d2e7465110497728e9f18ddef94cf133119acc3ea0aae7abb5725a60c11371f3bbbbcb743d089eddddadfe6257b5a5b649b0a5be8fd2dcbdb5e7655c7eb28b0b485bbcfd14d029b2f2f88ed4c6c1d5e184396b9b1227cd20f64447707c9fcf374efdcc42cc3bcc743c64ec1a04cffb9c5ff494e689ce27b4f8a25b246d6c92d8b1f83ab1afb5579ea9b9f6161606baed8d27214c693c75f969dbdb88e667fbf33b6da3f8352d7ebf96c72cf9fb99d46f9a9fc369c175e340fdee4f374acfef52d2201b3f97cb0b4f59f0acc86851d0f7a7a2938a08df1beff8142278da3e852b3fcdafeb2b099e7ccfb4372dafdcf6e152103cbb725bbd9377a8daa45081b896a69fdfc97df54ff6459264757a9e771ceed3db24e7cb4d629e9c6e12e756ad868f2fe47995cb33883d9100f36ffb428d0f487e07e927899ea0363050d070f5ca04527da427663a496d0073013629a70d2f786177c7d7b95fd84e2aab47365c927b4b6db38b85f4d3d4ee9afd113eb0919f90c8f73888705b6a42aeeb4f6d4b7fc714ed195b35130bafcdf61bbae63f3e2d0885ddd1592176f9d38ff66f45e47344699ee87c555afd53f9a2db85bc7b6d26d4f8a7edd5c1395a1834b63dde990d329ebafcb4ed6d44f7a73bff1ab18da337c977fd51e44b1a330a98f53c753fd16d1bf9e6a999e197f1d411aff4756d8cda779f9a5ca06da31cf4ebbb207d7f5df0743ae72d3c076cdde1c53bba90d687e085e7924e406d19f1b54063db874babe03505159904e438feb71ca3b8e0e99d2adcaf83b4ac9639a8b8b4127af518aeff66ced044a98eff62a46e2732fa7b083c7e952ccf6528cf20f6d42682eda365f50668759c134fd03868cc5b210a13484f4c1be8ab7e77c730d40ece5b0a3e39a49ec72faadd1d5f17c1db923a57675c302db5ed9cda61ba722b6cbbaba0bc6a6676c8fef955758fc6a52f6c99855daecf2da8f4ae84e11d16dbc33b232704e158ae8fe777797bdcca9d164b1357ffcf8c8ec56314761c737621608ff217254fd33c48d13ec7bf4bf3c45f0b147dd11e8df636f74818a8ed3ff98568da5ef74cf61efb77ec578d6d8f765a838c672c2869dbdbd0f7b7eea0221b3dfc02dd8ecce7ec8e39f569f71c54faceedbcf965bc737fbd6f46b4e0fa7815ca6adf7d6a7281b695d2b1e3c03b3cc297971c2bd6e8e34893eb3a98e029c41e2bbc6979474941f06895cbc1921f9a5fb5c77fa7c61f996b8b3d337773defeadde1b5a9d9da5eb57c9b1f899987be02b93dcaddc4f5ddd34cb34b1c22af3aa3f1be76714ee8dcfa5eaa84ca3578f57165f9be949724c16bc190a1a7a9716d0012c0e6632b96465e704845696b24a1ec09edaee4aefbc9c406ccc521f9c5d31d71e90ed6182a62b4d3b81c2ee399998f2f20489dae9b17973fac60b79a623476bb900a3770f19e41efa84dd1dc38247e325bb2b7fad8fb66d2f3c32a728edd4655a19af6dd9a0ed035138c24b824c06f12b6a7f64931b87851fc9d7ceae9ae9c7fe850c4a9360c469f3f2ecf696bc38933fa62bdb63dbb17a87ea187b483ec52706da569bce2f2f2cdca8829b8cc7ce8e3c3be6b1e55dd2ad7044a9b1e2d07b50b5ab344f6a34faa27f0ec873ca0a975f00d9f6521bfec96dba6fbee6fbf8a88ffb265a1834b7bd7e12d2e77846e5d7db1e9e8365db1bcf4fe9e3cde776bc33681b4fcfbe32733fb9676be4a722547e31a7119fe6341a4b7ecef788fc86fa4deae0f2d887f819e5574fcc1ccdab3097c4f7dd9c235fbc1ebd1c66e7ae3fddc8910bb4edb89d4f2216fe2dcd4848dc31a417c0bcc8543b292d9435067e8667779b41b03269de96f5ef2e563b4b5d4f94c7a65d3c22012cbeb472f2ec230a2e3cd8eeb3fbd6ac2e3e37e73908f25b8ee4e0f279b367e6fecd93d4e5fb9627b64dda5edb91fbaa604f93778e4229390d7f7a3b143cbef7ab494dbc3abdb254fd1d20e7b9fe4d1590027a15a8bfa7ab56d93df8b2fbb5a7bebb9260e61f72f302618d03317dd8be7912651f44d2a0a15793fc3b119b91c9adf0b61d9735ed9f3746e5d880d1f6f7891228d38020939d57ac553bcb6da39dc94faf4878251b05d43db370dbee906b477699b73053c4a65dba277a06b66c266491401ffe3398c5a7f202864d5b135fe04f6f63c74cf37dfd3ebf8bec59aec6e84dcfcc3ca0a0efc748b07dca6f2e460b1eedebb4f828fd0daa3e765fa68561719ed4c8f9e243737e9eca14b1b3f7f99748784ca5bd64d3b6f317ee9f2b14a8a43cf12bbf30686ebbde690d349e51f969db1fcac2262c5a52a2f949f5aa23caed791f2b2ab48de7677bca17a92d3fe61710e2d33b7b66c397bbb6199e7b9e1c27b176318afb6c818f8ac389cb9a99f66f23d318ccb0bff9c5a13cbfe5f6b97232e4026dbfc8ce8d45c3138efa72c783364fd3ae4aae67c42ca21fc12322bbd4f5d82e12386d8b085b954f0bafb5cda71df29f5e28ca8207c0b0e19767ded0aaff667e510106a33ab9c8a77f28467897545bd474835ca0fd10e8634f6081e08123a47a1ed974740506217dde765ce0b76fe363e12e910bb4470f1f2f1eddcee9630182078e0c59f5d37fd3fec80dbc1fe9f336702cc805daa3a6e998b3ebe07f000b0000a01340f00000007402081e0000804ed02e786b3f9b3f7cf17733f9493ffce407bc2dafef0e8dff9ac973e3e6c27f7269c795a3ec9f03f29f7f98df9dfbd9ace4d2dae0bc5f8c0b7ff8e1bff97b00001f3d2738f8e626f9cc650a00977f6d11bc5fcd854f420cfb0ce8d21736305a0ed2f683081ef7b3ae3781c7299b6f58f4d13fb5be3962513fb0e0d9be6db6b5a1ef0fbdcfdb9139eaec815003d0ce89951ffe9e09142a0840f02c6e17100546ee9b8103dffbeef06cfea30d702dfde3c42e6a13f5d791da7850c12bfa3773fc7d9c850f8207403b27b2135e070f9ffe4375ec5305b6723010317579a215b10b906979d1fd5ffcc3cc64ef57d7bd30ffa0d2fba8a74e9be0f52332d6165b57da273aad6ecb602bf58c2d4e8c03910817ea1e52ffe4174d8e4488d27be577b0b7a90f937176f7c7fe4294042feb4369df68dff2f03d0d3e2e65aab4e8776af3bfec6fddc769fe0312095e32a6ba4feca9cdcfe23f559aea83c86f9afc323316853afd784f86b2b88fad0fa7f70270d89cc805d0ec04f2934182ab0e180d13b6769f9fecb63e1d7427f9bbd453059c159a50f5bc69c07493d5ff9632bc3d0df548be947e7630a5c094f461d47637b9433089ed8adad35a0f93d49592e9835ab092ba633bdebf7f1a6c4ada648368cebec4d68cff44c151d2555ff1efc6e059f0a1d63ee7bc0de969dee877dd66a957894aeccb07279aaf1171bbe3be77f6f93e7663d8de47f576c5c4754a39e1b71de3d486bced000c1f7969a51800d2dfe2a4da61755a453a0965b2c9646f70f23480e9eb7a7265269f9f5cf1ef867ab2bca7e0497a25d6911db5bc5a6812d149837e96b67b4a751f52ff3052170733471833dd46aa93aecf90bfd97ad906675fa90fa3ef96ca9fdcb592e0957ca8d64729b6eed02e87d89fe68d7ed76d8ed3d3b157c87d495de93d8a66c18b7d25eeb3d48fb4bda96dfade4cbb22e27253512fdb00c0e1e2ded26427b613b1b6eaac0504edf0553e5fa0c53ab20e1082777411377fbd0a723219927bcbf6a4932ff9dd504f9df7143ca9a72158d7d27430b1f755365aca01201724eae5e4eb3ea4fea9e1c6df8d9b8c218f27d52776737f729af4ababb7686b6277ae0f38bff61345d187dac656ea6e484ff346bf539b1965b76efb7b120b9eebfb30ae555aff8267bfeb32aa729adb55bf1782078e17e1cf12eca4f9b5ee80b580a00380fe1e134fc226dc440913c02175ba499506b26250c94d46a6a19e405b406f9998b5e0a5eca8a5d9b2ac8dfa7bbfa4b6a46d2bd57d58fd93410b981bc3c9cb7edcb83efacecf857d9d455beb76d7fcab2078451fd2df759e00d7dd909ee68d7ee7fbda0b00ef729bfb7b30745f88a084b6c6be2269a1ced48fb4bd36adee274c7e2c9aea84e081e344f5777812a0c819d3c99d4cead8810bc140073c86cab9208e4d79d4440f9395eeaf26912e379e60f1e44a279ffedd508ffb1dd3474077fda327baf48dd49199e4a1edd6a65077524e1a10e27ec8910689243845e51f4dff701b629bad4d5560b3f56a7fb07da46d6bef435d479ceeead3fd1811e78f7c2815ad1a9cb7293d536e83dfa679b2c7f707a26e431847695bf55bec0b6392fa515c4eb35fd6db55aa332da76c0300874b25787e22aa20283807b662c8e889ea276f4ce4ece1bacfe78293bf1e059eea7a34095c10b72811ad4d3efdbba19e2c7dee604a7d11a525c14cdbefde924b034655a66e5f8e4c9088caa7c044ff86f2a3beb30cbd7f6afd42447ee4ead2d7244fd24f8d7d580fb2b1fd742fef164b6d68f2a19c1d115c7773baf671fbe6a2bf3767b345c6bbd8df6dd8b2437b6afdeaae9f235f50be3288e085fb7d5985c547a94e081e384e28c1eb320738b2fb282907ef66bad23f4701823c001f0a089ed091802ebb9cb61d640e08ded090ddd041c60000f0be40f03e71e263a983eceec030898ff400004709040f0000402780e0010000e804103c0000009d0082070000a01340f00000007402081e0000804e00c1030000d00920780000003a01040f0000402780e0010000e804103c0000009d0082070000a01340f00000007402081e0000804e00c1030000d00920780000003a01040f0000402780e0010000e804103c0000009d0082070000a01340f000000074805df3ff0248fa974c800e220000000049454e44ae426082);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_logactivity`
--

CREATE TABLE `tbl_logactivity` (
  `logId` int(50) NOT NULL,
  `role` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `time` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `activity` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_logactivity`
--

INSERT INTO `tbl_logactivity` (`logId`, `role`, `username`, `time`, `activity`) VALUES
(17, 'Customer', 'cust1', '2024-05-14 13:36:46', 'Login'),
(18, 'Customer', 'cust1', '2024-06-14 23:55:23', 'Login'),
(19, 'Customer', 'cust1', '2024-06-15 00:36:36', 'Login'),
(20, 'Customer', 'cust1', '2024-06-15 00:41:50', 'Login'),
(21, 'Customer', 'cust1', '2024-06-15 00:44:33', 'Login'),
(22, 'Customer', 'cust1', '2024-06-15 01:02:22', 'Login'),
(23, 'Customer', 'cust1', '2024-06-15 01:03:33', 'Login'),
(24, 'Cashier', 'cash1', '2024-06-15 02:09:20', 'Login'),
(25, 'Cashier', 'cash1', '2024-06-15 02:11:58', 'Login'),
(26, 'Cashier', 'cash1', '2024-06-15 02:14:02', 'Login'),
(27, 'Cashier', 'cash1', '2024-06-15 02:26:56', 'Login'),
(28, 'Cashier', 'cash1', '2024-06-15 02:27:51', 'Login'),
(29, 'Cashier', 'cash1', '2024-06-15 02:28:48', 'Login'),
(30, 'Cashier', 'cash1', '2024-06-15 02:36:46', 'Login'),
(31, 'Cashier', 'cash1', '2024-06-15 02:46:58', 'Login'),
(32, 'Cashier', 'cash1', '2024-06-15 02:47:23', 'Login'),
(33, 'Cashier', 'cash1', '2024-06-15 02:48:13', 'Login'),
(34, 'Cashier', 'cash1', '2024-06-15 02:55:19', 'Login'),
(35, 'Admin', 'cash1', '2024-06-14 17:00:00', 'Login'),
(36, 'Cashier', 'cash1', '2024-06-15 02:56:38', 'Login'),
(37, 'Admin', 'adm1', '2024-06-15 02:57:58', 'Login'),
(38, 'Cashier', 'cash1', '2024-06-15 03:10:52', 'Login'),
(39, 'Cashier', 'cash1', '2024-06-15 03:12:11', 'Login'),
(40, 'Cashier', 'cash1', '2024-06-15 03:15:18', 'Login'),
(41, 'Cashier', 'cash1', '2024-06-15 03:17:22', 'Login');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_owner`
--

CREATE TABLE `tbl_owner` (
  `id` int(11) NOT NULL,
  `username` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `password` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_owner`
--

INSERT INTO `tbl_owner` (`id`, `username`, `password`) VALUES
(1, 'owner', '123');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_products`
--

CREATE TABLE `tbl_products` (
  `id` int(50) NOT NULL,
  `productName` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `category` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `price` bigint(50) NOT NULL,
  `quantity` int(50) NOT NULL,
  `supplierId` int(50) NOT NULL,
  `expDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_products`
--

INSERT INTO `tbl_products` (`id`, `productName`, `category`, `price`, `quantity`, `supplierId`, `expDate`) VALUES
(1, 'sepatu emas', 'Food', 100000, 234234, 1, '2024-06-13'),
(2, 'kapur barus', 'Non Food', 5000, 345345, 1, NULL),
(4, 'sdfsdf', 'Food', 234234, 2323, 1, '2024-06-13');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sales`
--

CREATE TABLE `tbl_sales` (
  `saleId` int(50) NOT NULL,
  `cashierName` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `saleDate` date NOT NULL,
  `customerId` int(50) NOT NULL,
  `productName` varchar(150) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `paymentType` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `total` bigint(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_sales`
--

INSERT INTO `tbl_sales` (`saleId`, `cashierName`, `saleDate`, `customerId`, `productName`, `paymentType`, `total`) VALUES
(1, 'cash1', '2024-06-15', 1, 'sepatu emas', 'Cash', 2100000);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_supplier`
--

CREATE TABLE `tbl_supplier` (
  `supplierId` int(50) NOT NULL,
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `telp` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `email` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_supplier`
--

INSERT INTO `tbl_supplier` (`supplierId`, `name`, `telp`, `email`) VALUES
(1, 'starbuck', '9238472', 'starbuck@gmail.com'),
(2, 'adidas', '35234234', 'adidas@gmail.com'),
(3, 'joyko', '56463443', 'joyko@gmail.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`adminId`);

--
-- Indexes for table `tbl_atm`
--
ALTER TABLE `tbl_atm`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `tbl_atmtransaction`
--
ALTER TABLE `tbl_atmtransaction`
  ADD PRIMARY KEY (`atmTrId`);

--
-- Indexes for table `tbl_cashier`
--
ALTER TABLE `tbl_cashier`
  ADD PRIMARY KEY (`cashierId`);

--
-- Indexes for table `tbl_customer`
--
ALTER TABLE `tbl_customer`
  ADD PRIMARY KEY (`customerId`);

--
-- Indexes for table `tbl_events`
--
ALTER TABLE `tbl_events`
  ADD PRIMARY KEY (`eventId`);

--
-- Indexes for table `tbl_logactivity`
--
ALTER TABLE `tbl_logactivity`
  ADD PRIMARY KEY (`logId`);

--
-- Indexes for table `tbl_owner`
--
ALTER TABLE `tbl_owner`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_products`
--
ALTER TABLE `tbl_products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_sales`
--
ALTER TABLE `tbl_sales`
  ADD PRIMARY KEY (`saleId`);

--
-- Indexes for table `tbl_supplier`
--
ALTER TABLE `tbl_supplier`
  ADD PRIMARY KEY (`supplierId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `adminId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_atmtransaction`
--
ALTER TABLE `tbl_atmtransaction`
  MODIFY `atmTrId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_cashier`
--
ALTER TABLE `tbl_cashier`
  MODIFY `cashierId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbl_customer`
--
ALTER TABLE `tbl_customer`
  MODIFY `customerId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbl_events`
--
ALTER TABLE `tbl_events`
  MODIFY `eventId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbl_logactivity`
--
ALTER TABLE `tbl_logactivity`
  MODIFY `logId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- AUTO_INCREMENT for table `tbl_owner`
--
ALTER TABLE `tbl_owner`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_products`
--
ALTER TABLE `tbl_products`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbl_sales`
--
ALTER TABLE `tbl_sales`
  MODIFY `saleId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_supplier`
--
ALTER TABLE `tbl_supplier`
  MODIFY `supplierId` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
